using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : SnowBall
{
   protected override void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            // Do not damage flags
            if (!damageable.Object.tag.Equals( "Flag" ) )
            {
                DoDamage(damageable);
            }           

            // sound effect
            // particle effect
        }
    }
}
