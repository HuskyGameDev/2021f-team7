using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 7.0f;

    void Update()
    {
        CheckForUserInput();
    }

    // checks every frame for user input on the w,a,s,d keys and then moves the player accordingly
    void CheckForUserInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left);
        }

        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.down);
        }

        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.up);
        }
    }

    // if the player enters a trigger of a gameobject with interface IInteractable, it will call the Interact()
    void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null)
        {
            interactable.Interact();
        }
    }

    void MovePlayer(Vector3 direction)
    {
        this.gameObject.transform.Translate(direction * Time.deltaTime * movementSpeed);
    }

}
