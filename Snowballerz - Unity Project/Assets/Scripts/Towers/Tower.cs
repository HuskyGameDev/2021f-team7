using UnityEngine;
using System.Collections.Generic;

enum HealthState
{
    FullyHealed,
    Damaged,
    AlmostDestroyed
}

public class Tower : MonoBehaviour, IDamageable
{
    // snowball that the tower shoots
    SnowBall snowball;

    int health;

    Dictionary<HealthState, Sprite> towerSprites = new Dictionary<HealthState, Sprite>();

    void IDamageable.TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }
}
