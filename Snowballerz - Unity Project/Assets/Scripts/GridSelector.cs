using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSelector : MonoBehaviour
{
    [ SerializeField ]
    private float margin;

    private Transform tf;

    private SpriteRenderer sprRend;

    private void Awake()
    {
        this.tf = this.transform;
        this.sprRend = this.GetComponent<SpriteRenderer>();
    }

    public void Select( GridSquare square )
    {
        var squareTF = square.transform;
        var squareBounds = square.GetBounds();
        // Set position of selector onto gridsquare.
        this.tf.position = new Vector3( squareTF.position.x, squareTF.position.y, this.tf.position.z );
        // Set selector's sprite size to be that of the gridsquare + a margin.
        this.sprRend.size = new Vector2( squareBounds.size.x + margin, squareBounds.size.y + margin );
    }
}
