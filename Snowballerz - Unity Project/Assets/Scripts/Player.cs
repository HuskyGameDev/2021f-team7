using UnityEngine;
using System;

[ RequireComponent( typeof( PlayerGridSelection ) ) ]
public class Player : MonoBehaviour, IDamageable
{
    public static event Action<int> OnSnowCountChange;

    // Public / Exposed fields. //
    [ SerializeField ]
    float movementSpeed = 7.0f;

    [SerializeField]
    int snowCount;

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

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.playerSelection = this.GetComponent<PlayerGridSelection>();
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

        input.Player_1.Action.performed += ctx => 
        {
            var selected = this.playerSelection.GetSelected();

            // the selected square is the square which is nearest to the player and is flashing red
            if ( selected != null )
            {
                selected.selectedSquare.Interact(this);
            }
            //else
            //{
            //    // logic for placing towers goes here

            //    // temporary
            //    //selected.selectedSquare.Place(peaShooter);
            //}
        };

        // Enable in case the global input actions were previously disabled.
        input.Enable();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        this.rb.position += this.movementDirection * Time.deltaTime * movementSpeed;
    }

    public void TakeDamage(int amount)
    {
        throw new NotImplementedException();
    }
}
