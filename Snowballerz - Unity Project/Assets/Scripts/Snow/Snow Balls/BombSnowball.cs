using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombSnowball : SnowBall
{
    List<IDamageable> towersHitByBomb = new List<IDamageable>();

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            var hitsUp = Physics2D.RaycastAll(damageable.Object.transform.position, Vector2.up, 2);
            var hitsDown = Physics2D.RaycastAll(damageable.Object.transform.position, Vector2.down, 2);

            // Iterate through all raycast hits, both up and down.
            foreach ( var rc in hitsUp.Concat(hitsDown) )
            {
                // Don't adjacently damage flags
                if ( rc.collider != null && rc.collider.gameObject.tag != "Flag" )
                {
                    var damCom = rc.collider.gameObject.GetComponent<IDamageable>();

                    if (damCom != null)
                        towersHitByBomb.Add(damCom);
                }
            }

            towersHitByBomb.Add(damageable);

            foreach (var tower in towersHitByBomb)
            {
                base.DoDamage(tower);
            }

            Destroy(gameObject);
        }
    }
}