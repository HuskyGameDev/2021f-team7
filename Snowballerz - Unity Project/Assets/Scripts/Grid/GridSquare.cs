using UnityEngine;

public class GridSquare : MonoBehaviour, IInteractable
{
    private GridObject currentObject;

    [Tooltip("A prefab to create and place on this tile during Start(). If none, this tile will start empty.")]
    [SerializeField]
    private GridObject initialObject;
    [SerializeField]
    private int flakesNeeded;

    private SpriteRenderer sprRend;

    private int flakesFallen = 0;

    private void Awake()
    {
        sprRend = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        // If a prefab for the initial grid object is defined.
        if ( this.initialObject != null ) 
        {
            //var go = GameObject.Instantiate( initialObject );

            Place(initialObject);
        }
    }

    public bool HasCurrentObject()
    {
        return this.currentObject != null;
    }

    public bool Interact(Player player)
    {
        if (this.currentObject != null)
        {
            this.currentObject.Interact(player);
            return true;
        }

        return false;
    }

    public void Place( GridObject gridObject )
    {
        gridObject = Instantiate(gridObject);

        this.currentObject = gridObject;

        gridObject.transform.parent = this.transform;
        // Place in the middle & in front of the the grid square.
        gridObject.transform.localPosition = new Vector3( 0, 0, -1 );
    }

    //Returns the visual bounds in world space of the grid square.
    public Bounds GetBounds()
    {
        return sprRend.bounds;
    }

    // Called when a snowfall particle lands on the tile
    public void addFlake()
    {
        flakesFallen++;
        if (flakesFallen >= flakesNeeded && !HasCurrentObject())
        {
            flakesFallen = 0;
            if (this.initialObject != null)
            {
                Place(initialObject);
            }
            else
            {
                Debug.Log("GridSquare.cs: place snow tile in initialObject");
            }
        }
    }

}