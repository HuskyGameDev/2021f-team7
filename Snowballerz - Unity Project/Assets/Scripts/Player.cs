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
    PlayerInputWrapper.Players player;

    [ SerializeField ]
    float movementSpeed = 7.0f;

    [ SerializeField ]
    int snowCount;

    [ SerializeField ]
    SelectionWheel selectionWheel;

    [ SerializeField ]
    SW_List testList;

    [ SerializeField ]
    GameObject destroyItem;

    [ SerializeField ]
    PeaShooter peaShooter;

    [ SerializeField ]
    List<Tower> towers = new List<Tower>();

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
                    if (!selected.selectedSquare.HasCurrentObject())
                    {
                        foreach (var tower in towers)
                        {
                            if (tower.id == seld.Item2)
                            {
                                if (SnowCount >= tower.SnowBallCost)
                                {
                                    var go = GameObject.Instantiate( tower );
                                    // Assign the tower to the player collision layer that we're on.
                                    go.gameObject.layer = this.gameObject.layer;
                                    selected.selectedSquare.Place( go );
                                    SnowCount -= tower.SnowBallCost;
                                    tower.Placed = true;
                                }
                            }
                        }
                    }
                    else 
                    {
                        Debug.Log( "Couldn't build onto GridSquare: Has a GridObject on it!" );
                    }
                }

                this.selectionWheel.HideWheel();
                this.lastSelectedItem = seld.Item2;
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
            this.selectionWheel.ShowWheel( 
                new SelectionWheel.SelectionConfig (
                    this.testList,
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
            this.lastSelectedItem = seld.Item2;
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
}
