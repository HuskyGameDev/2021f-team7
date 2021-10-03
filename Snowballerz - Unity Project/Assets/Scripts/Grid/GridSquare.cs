using UnityEngine;

public class GridSquare : MonoBehaviour, IInteractable
{
    private GridObject currentObject;

    // temporary tower for testing purposes
    [SerializeField]
    PeaShooter peaShooter;

    [Tooltip("A prefab to create and place on this tile during Start(). If none, this tile will start empty.")]
    [SerializeField]
    private GridObject initialObject;

    private SpriteRenderer sprRend;

    private void Awake()
    {
        sprRend = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        peaShooter = Resources.Load<PeaShooter>("PeaShooter");

        // If a prefab for the initial grid object is defined.
        if ( this.initialObject != null ) 
        {
            var go = GameObject.Instantiate( initialObject );

            Place( go );
        }
    }

    public void Interact( Player player )
    {
        if ( this.currentObject != null )
        {
            this.currentObject.Interact(player);
        }
        else
        {
            Place(peaShooter);
        }
    }

    public void Place( GridObject gridObject )
    {
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

}