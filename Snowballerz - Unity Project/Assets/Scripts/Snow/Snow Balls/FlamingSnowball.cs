using System.Collections;
using UnityEngine;

public class FlamingSnowball : SnowBall
{
    [SerializeField]
    int burnTime;

    [SerializeField]
    int burnDamage;

    protected override void DoDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);

        Burnable burnable = damageable.Object.GetComponent<Burnable>();

        if (burnable != null)
        {
            if (burnable.IsBurned == false)
            {
                burnable.IsBurned = true;
            }
        }
    }
}