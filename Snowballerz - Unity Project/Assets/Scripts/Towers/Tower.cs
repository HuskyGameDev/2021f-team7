using UnityEngine;
using System.Collections.Generic;

enum HealthState
{
    FullyHealed,
    Damaged,
    AlmostDestroyed
}

enum Direction
{
    Left, Right
}

public class Tower : GridObject, IDamageable
{
    // snowball that the tower shoots
    [SerializeField]
    SnowBall snowball;

    Direction facingDirection;

    int health;

    Vector3 spawnPosOfSnowball;

    Dictionary<HealthState, Sprite> towerSprites = new Dictionary<HealthState, Sprite>();

    void IDamageable.TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    void Shoot()
    {
        Instantiate(snowball, spawnPosOfSnowball, Quaternion.identity);
    }

    public override void Interact(Player player)
    {
        throw new System.NotImplementedException();
    }
}
