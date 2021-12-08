using UnityEngine;
using System;
using System.Collections.Generic;
using static PlayerInputWrapper;

[ RequireComponent( typeof( PlayerGridSelection ) ) ]
public class Player : MonoBehaviour, IDamageable
{
    public event Action<int> OnSnowCountChange;

    // Public / Exposed fields. //
    [ SerializeField ]
    Players player;

    [ SerializeField ]
    float movementSpeed = 7.0f;

    [ SerializeField ]
    int snowCount;

    [ SerializeField ]
    SelectionWheel selectionWheel;

    [ SerializeField ]
    BuildableSelection[] towerSWList;

    [ SerializeField ]
    GameObject destroyItem;

    public int SnowCount
    {
        get { return snowCount; }

        set
        {
            snowCount = value;

            if (OnSnowCountChange != null)
            {
                OnSnowCountChange(snowCount);
            }
        }
    }

    public GameObject Object
    {
        get { return this.gameObject; }
    }

    // Private / Unexposed fields. //
    private Vector2 movementDirection = Vector2.zero;

    private Rigidbody2D rb;

    private PlayerGridSelection playerSelection;

    private bool selectingFromWheel = false;

    private int lastSelectedItem = 0;

    private Animator animator;

    private Vector2 lastPosition;

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.playerSelection = this.GetComponent<PlayerGridSelection>();
        this.animator = this.GetComponent<Animator>();

        this.lastPosition = this.transform.position;
    }

    private void Start()
    {
        this.SnowCount = 0;

        var input = GlobalInputActions.Instance;

        var moveIA = GetInputAction( input, Actions.Move, this.player );
        var actionIA = GetInputAction( input, Actions.Action, this.player );
        var selectIA = GetInputAction( input, Actions.Select, this.player );
        var selectDirectionIA = GetInputAction( input, Actions.SelectDirection, this.player );

        moveIA.performed += ctx => 
        {
            movementDirection = ctx.ReadValue<Vector2>();
        };

        moveIA.canceled += ctx =>
        {
            movementDirection = Vector2.zero;
        };

        // R button
        actionIA.performed += ctx => 
        {
            var selected = this.playerSelection.GetSelected();

            if ( this.selectingFromWheel ) {
                var seld = this.selectionWheel.GetSelected();

                Debug.Log("Selected ID: " + ( (seld.Item1 == SelectionWheel.VerticalOptions.Top) ? seld.Item2.ToString() : "BottomOption!") );

                // the selected square is the square which is nearest to the player and is flashing red
                if ( selected != null )
                {
                    // if the grid object on the selected square was empty, we can place a tower
                    if ( !selected.selectedSquare.HasCurrentObject() )
                    {
                        var itemTuple = ((GameObject, int))seld.Item2;

                        if (SnowCount >= itemTuple.Item2)
                        {
                            var gameObj = GameObject.Instantiate(itemTuple.Item1);
                            var gridObj = gameObj.GetComponent<GridObject>();
                            // Assign the tower to the player collision layer that we're on.
                            gameObj.gameObject.layer = this.gameObject.layer;

                            foreach ( Transform c in gameObj.GetComponentsInChildren<Transform>() ) 
                            {
                                c.gameObject.layer = this.gameObject.layer;
                            }

                            // If tower is IDirectionable, give it a direction.
                            if ( gridObj is IDirectionable ) 
                            {
                                // TODO: Make this not hard-coded if theres even another map made.
                                Vector2 targetDir =
                                    this.player == Players.Player_1 ? Vector2.right : Vector2.left;

                                ( (IDirectionable)gridObj ).SetDirection( targetDir );
                            }

                            selected.selectedSquare.Place( gridObj );
                            SnowCount -= itemTuple.Item2;
                            gameObj.GetComponent<Tower>().Placed = true;
                        }
                    }
                    else 
                    {
                        // If we're trying to destroy the object.
                        if ( seld.Item1 == SelectionWheel.VerticalOptions.Bottom )
                        {
                            // If the selected object to destroy isn't a snowsquare
                            if ( selected.selectedSquare.GetGOTag() != "SnowSquare" )
                            {
                                var removed = selected.selectedSquare.RemoveGridObject();
                                GameObject.Destroy( removed.gameObject );
                            }
                        }
                        else
                        {
                            Debug.Log("Couldn't build onto GridSquare: Has a GridObject on it!");
                        }
                    }
                }

                this.selectionWheel.HideWheel();
                this.lastSelectedItem = seld.Item3;
                this.selectingFromWheel = false;
                return;
            }

            // the selected square is the square which is nearest to the player and is flashing red
            if (selected != null)
            {
                selected.selectedSquare.Interact(this);
            }
        };

        // T button
        selectIA.performed += ctx =>
        {
            this.selectingFromWheel = true;

            // Create selection list for wheel.
            List<SW_Item> items = new List<SW_Item>();
            
            foreach ( var sel in this.towerSWList ) 
            {
                SW_Item item = new SW_Item();

                item.Visual = sel.visual;
                // Assign the SW_Item's value to be a tuple of the tower's prefab & cost.
                item.Value = (sel.prefab, sel.cost);
                items.Add(item);
            }

            this.selectionWheel.ShowWheel( 
                new SelectionWheel.SelectionConfig (
                    new SW_List( items.ToArray() ),
                    this.lastSelectedItem,
                    true,
                    this.destroyItem
                ) 
            );
        };

        selectIA.canceled += ctx =>
        {
            // If we've already stopped selecting from the wheel, return;
            if (!this.selectingFromWheel) return;

            var seld = this.selectionWheel.GetSelected();
            this.lastSelectedItem = seld.Item3;
            this.selectingFromWheel = false;
            this.selectionWheel.HideWheel();
        };

        selectDirectionIA.performed += ctx =>
        {
            var vec = ctx.ReadValue<Vector2>();

            // Ignore if two directions are being pressed at the same time.
            if ( Mathf.Abs(vec.x) > 0 && Mathf.Abs(vec.y) > 0 ) return;

            // Right
            if      (vec.x > 0)
                this.selectionWheel.Move( SelectionWheel.SelectionMove.Right );
            // Left
            else if (vec.x < 0)
                this.selectionWheel.Move( SelectionWheel.SelectionMove.Left );
            // Up
            else if (vec.y > 0)
                this.selectionWheel.Move( SelectionWheel.SelectionMove.Up );
            // Down
            else if (vec.y < 0)
                this.selectionWheel.Move( SelectionWheel.SelectionMove.Down );
        };

        // Enable in case the global input actions were previously disabled.
        input.Enable();
    }

    private void Update()
    {
        // Move the player if not currently selecting from a selection wheel.
        MovePlayer();
    }

    private void FixedUpdate()
    {
        var currentPos = (Vector2) this.transform.position;
        var movedDist = currentPos - this.lastPosition;

        animator.SetFloat( "CurrentSpeed", movedDist.magnitude );

        this.lastPosition = currentPos;
    }

    /// <summary>
    /// Performs the movement, checking for movement, and movement animation triggering for the player.
    /// </summary>
    private void MovePlayer()
    {
        var dir = this.movementDirection;
        
        // If the player should stop since they're selecting from the wheel.
        if ( this.selectingFromWheel )
        {
            return;
        }

        // If the player is to move.
        this.rb.position += this.movementDirection * Time.deltaTime * movementSpeed;

        // Set the animation flip direction.
        if (dir.x > 0)
        {
            this.animator.SetBool( "FacingRight", true );
        }
        else if (dir.x < 0)
        {
            this.animator.SetBool( "FacingRight", false );
        }
    }

    public void TakeDamage(int amount)
    {
        throw new NotImplementedException();
    }

    void IDamageable.TakeDamage(int amount)
    {
        throw new NotImplementedException();
    }
}
