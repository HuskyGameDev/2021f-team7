using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballDespawner : MonoBehaviour
{
    /// <summary>
    /// Destroy all GameObjects which have a "Snowball" tag.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.gameObject.tag.Equals( "Snowball" ) ) 
        {
            GameObject.Destroy( collision.gameObject );
        }
    }
}
