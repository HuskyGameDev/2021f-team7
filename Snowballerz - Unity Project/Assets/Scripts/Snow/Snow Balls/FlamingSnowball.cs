using System.Collections;
using UnityEngine;

public class FlamingSnowball : SnowBall
{
    //Will burn tower over time, but can tower be burned twice?
    [SerializeField]
    int burnTime;

    [SerializeField]
    int burnDamage;

    protected override void DoDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);

        GameObject obj = damageable.Object;
        Burnable burnable = obj.GetComponent<Burnable>();

        if (burnable != null)
        {
            if (burnable.IsBurned == false)
            {
                burnable.IsBurned = true;
            }
        }
    }
}