using UnityEngine;

public class GridSquare : MonoBehaviour, IInteractable
{
    public enum GSState { Placeable, Unplaceable };
    
    public static event System.Action PlaceTower;

    public GSState State { get; set; } = GSState.Placeable;

    private GridObject currentObject;

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
        // If a prefab for the initial grid object is defined.
        if ( this.initialObject != null ) 
        {
            var go = GameObject.Instantiate( initialObject );
            Place( go );
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

    /// <summary>
    /// Places a pre-instantiated gameobject with a GridObject components onto this GridSquare.
    /// 
    /// Returns whether the GridObject was sucessfully placed on the GridSquare.s
    /// </summary>
    /// <param name="gridObject"></param>
    public bool Place( GridObject gridObject )
    {
        if ( this.State != GSState.Placeable )
            return false;

        this.currentObject = gridObject;

        gridObject.transform.parent = this.transform;
        // Place in the middle & in front of the the grid square.
        gridObject.transform.localPosition = new Vector3( 0, 0, -1 );

        return true;
    }

    public GridObject RemoveGridObject()
    {
        var gridObj = this.currentObject;

        if ( gridObj == null )
            return null;

        this.currentObject = null;

        return gridObj;
    }

    //Returns the visual bounds in world space of the grid square.
    public Bounds GetBounds()
    {
        return sprRend.bounds;
    }

}