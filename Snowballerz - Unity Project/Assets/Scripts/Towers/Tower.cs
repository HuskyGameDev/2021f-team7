using UnityEngine;
using System.Collections.Generic;
using System.Collections;

enum HealthState
{
    FullyHealed,
    Damaged,
    AlmostDestroyed
}

public class Tower : GridObject, IDamageable
{
    // snowball that the tower shoots
    [SerializeField]
    SnowBall snowball;

    // its only set to true temporarly. Later we need to know which direction player 1 and 2 is facing
    bool facingRight = true;

    [SerializeField]
    int health;

    [SerializeField]
    int fireRate;

    [SerializeField]
    int snowballCostToPlace;

    // this will be different for every tower because they are not all the same width and height
    [SerializeField]
    Transform spawnPosOfSnowball;

    Dictionary<HealthState, Sprite> towerSprites = new Dictionary<HealthState, Sprite>();

    void Start()
    {
        snowball.isFacingRight = facingRight;

        StartCoroutine(ShootSnowBall());
    }

    IEnumerator ShootSnowBall()
    {
        while (true)
        {
            Instantiate(snowball, spawnPosOfSnowball.position, Quaternion.identity);
            yield return new WaitForSeconds(fireRate);
        }
    }

    void IDamageable.TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    public override void Interact(Player player)
    {
        throw new System.NotImplementedException();
    }
}