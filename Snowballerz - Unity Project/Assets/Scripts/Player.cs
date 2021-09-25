using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

[ RequireComponent( typeof( PlayerGridSelection ) ) ]
public class Player : MonoBehaviour
{
    // Public / Exposed fields. //
    [ SerializeField ]
    private float movementSpeed = 7.0f;

    [field: SerializeField] public int Snow { get; set; } = 0;

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

            if ( selected != null )
                selected.selectedSquare.Interact( this );
        };

        // Enable in case the global input actions were previously disabled.
        input.Enable();
    }

    private void Update()
    {
        this.MovePlayer();
    }

    private void MovePlayer()
    {
        this.rb.position += this.movementDirection * Time.deltaTime * movementSpeed;
    }

}
