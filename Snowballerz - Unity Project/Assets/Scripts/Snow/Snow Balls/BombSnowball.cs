using System.Collections.Generic;
using UnityEngine;

public class BombSnowball : SnowBall
{
    List<IDamageable> towersHitByBomb = new List<IDamageable>();

    void Start()
    {
        Physics2D.queriesStartInColliders = false; // the ray no longer detects it's own collider
    }

    protected override void Update()
    {
        base.Update();

        Debug.DrawRay(transform.position, Vector2.up * 1.75f, Color.red);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            int mask = LayerMask.GetMask("Snowball");

            RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.up, 2, mask , -2, 2);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.down, 2, mask, -2, 2);

            if (hit1.collider != null)
            {
                if (hit1.collider.gameObject.GetComponent<IDamageable>() != null)
                {
                    towersHitByBomb.Add(hit1.collider.gameObject.GetComponent<IDamageable>());
                }
            }

            //if (hit2.collider.gameObject.GetComponent<IDamageable>() != null)
            //{
            //    towersHitByBomb.Add(hit2.collider.gameObject.GetComponent<IDamageable>());
            //}

            //towersHitByBomb.Add(damageable);

            //foreach (var tower in towersHitByBomb)
            //{
            //    DoDamage(tower);
            //}

            print(towersHitByBomb.Count);

            Destroy(gameObject);
        }
    }

    protected override void DoDamage(IDamageable damageable)
    {
       
    }
}