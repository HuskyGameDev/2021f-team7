using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour, IInteractable
{

    private GridObject currentObject = null;

    [ Tooltip("A prefab to create and place on this tile during Start(). If none, this tile will start empty.") ]
    [ SerializeField ]
    private GridObject initialObject = null;

    private SpriteRenderer sprRend;

    private void Awake()
    {
        this.sprRend = this.GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        // If a prefab for the initial grid object is defined.
        if ( this.initialObject != null ) 
        {
            var go = GameObject.Instantiate( initialObject );

            this.Place( go );
        }
    }

    public void Interact( Player player )
    {
        if ( this.currentObject != null )
            this.currentObject.Interact( player );
    }

    public void Place( GridObject gridObject )
    {
        this.currentObject = gridObject;

        gridObject.transform.parent = this.transform;
        // Place in the middle & in front of the the grid square.
        gridObject.transform.localPosition = new Vector3( 0, 0, -1 );
    }

    /// <summary>
    /// Returns the visual bounds in world space of the grid square.
    /// </summary>
    /// <returns></returns>
    public Bounds GetBounds()
    {
        return this.sprRend.bounds;
    }

}
