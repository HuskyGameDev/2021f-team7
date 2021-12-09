using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAE : MonoBehaviour
{
    public void DestroyExplosion()
    {
        GameObject.Destroy( this.gameObject );
    }
}
