using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : SnowBall
{
    [ SerializeField ]
    private GameObject explosionEffect;

   protected override void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            // Do not damage flags
            if (!damageable.Object.tag.Equals("Flag"))
            {
                DoDamage(damageable);
            }
            else
            {
                var explosion = GameObject.Instantiate( this.explosionEffect, this.transform.position, Quaternion.Euler( 0, 0, 0 ) );

                // Make explosion tiny.
                explosion.transform.localScale = new Vector3( 0.3f, 0.3f, 1 );

                // Destroy self on flag.
                Destroy( this.gameObject );
            }

            // sound effect
            // particle effect
        }
    }
}
