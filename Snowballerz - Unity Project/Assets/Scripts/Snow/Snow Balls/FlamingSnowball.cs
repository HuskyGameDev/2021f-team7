using UnityEngine;

public class FlamingSnowball : SnowBall
{
    [SerializeField]
    int burnDamage;

    protected override void DoDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);

        Burnable burnable = damageable.Object.GetComponent<Burnable>();

        if ( burnable != null )
            burnable.StartBurn();
    }
}