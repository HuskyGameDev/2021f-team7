using UnityEngine;
using System;
using System.Collections.Generic;

[ RequireComponent( typeof( PlayerGridSelection ) ) ]
public class Player : MonoBehaviour, IDamageable
{
    public static event Action<int> OnSnowCountChange;

    // Public / Exposed fields. //
    [ SerializeField ]
    float movementSpeed = 7.0f;

    [ SerializeField ]
    int snowCount;

    [ SerializeField ]
    SelectionWheel selectionWheel;

    [ SerializeField ]
    SW_List testList;

    [SerializeField]
    GameObject destroyItem;

    [SerializeField]
    PeaShooter peaShooter;

    [SerializeField]
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

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.playerSelection = this.GetComponent<PlayerGridSelection>();
        this.animator = this.GetComponent<Animator>();
    }

    private void Start()
    {
        SnowCount = 0;

        var input = GlobalInputActions.Instance;

        input.Player_1.Move.performed += ctx => 
        {
            movementDirection = ctx.ReadValue<Vector2>();
        };

        input.Player_1.Move.canceled += ctx =>
        {
            movementDirection = Vector2.zero;
        };

        // R button
        input.Player_1.Action.performed += ctx => 
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
                                selected.selectedSquare.Place(tower);
                                tower.placed = true;
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
        input.Player_1.Select.performed += ctx =>
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

        input.Player_1.Select.canceled += ctx =>
        {
            // If we've already stopped selecting from the wheel, return;
            if (!this.selectingFromWheel) return;

            var seld = this.selectionWheel.GetSelected();
            this.lastSelectedItem = seld.Item2;
            this.selectingFromWheel = false;
            this.selectionWheel.HideWheel();
        };

        input.Player_1.SelectDirection.performed += ctx =>
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

    /// <summary>
    /// Performs the movement, checking for movement, and movement animation triggering for the player.
    /// </summary>
    private void MovePlayer()
    {
        var dir = this.movementDirection;
        
        // If the player is not moving / cannot move.
        if (this.selectingFromWheel || dir == Vector2.zero)
        {
            this.animator.SetBool("Moving", false);
            return;
        }
        // If the player is to move.
        this.rb.position += this.movementDirection * Time.deltaTime * movementSpeed;

        this.animator.SetBool("Moving", true);

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
