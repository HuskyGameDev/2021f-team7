using System.Collections;
using UnityEngine;

public class FlamingSnowball : SnowBall
{
    //Will burn tower over time, but can tower be burned twice?
    [SerializeField]
    int burnTime;

    //protected override void DoDamage(IDamageable obj)
    //{
    //    throw new System.NotImplementedException();
    //}

    IEnumerator BurnEnemy(IDamageable obj)
    {
        while(true)
        {
            // burn obj logic

            yield return new WaitForSeconds(burnTime);
        }
    }
}