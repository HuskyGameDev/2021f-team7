using System.Collections.Generic;
using UnityEngine;

public class BombChecker : MonoBehaviour
{
    List<IDamageable> towersHitByBomb = new List<IDamageable>();

    public void SendList(List<IDamageable> towers)
    {
        towersHitByBomb = towers;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            towersHitByBomb.Add(damageable);
        }
    }
}