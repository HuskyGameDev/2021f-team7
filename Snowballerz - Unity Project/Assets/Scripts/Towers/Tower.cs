using UnityEngine;
using System.Collections.Generic;
using System.Collections;

enum HealthState
{
    FullyHealed,
    Damaged,
    AlmostDestroyed
}

public class Tower : GridObject, IDamageable, IPlaceableByPlayer
{
    // snowball that the tower shoots
    [SerializeField]
    SnowBall snowball;

    [SerializeField]
    new string name;

    // its only set to true temporarly. Later we need to know which direction player 1 and 2 is facing
    bool facingRight = true;

    [SerializeField]
    int health;

    int Health
    {
        get { return health; }

        set
        {
            if (health <= 0)
            {
                health = 0;
                Die();
            }
            else
            {
                health = value;
            }
        }
    }

    [SerializeField]
    int fireRate;

    [SerializeField]
    int snowballCostToPlace;

    public int SnowBallCost
    {
        get { return snowballCostToPlace; }
    }

    // this will be different for every tower because they are not all the same width and height
    [SerializeField]
    Transform spawnPosOfSnowball;

    Dictionary<HealthState, Sprite> towerSprites = new Dictionary<HealthState, Sprite>();

    bool placed = false;

    public bool Placed
    {
        get { return placed; }

        set 
        {
            value = placed;
        }
    }

    public int id;

    void Start()
    {
        StartCoroutine(ShootSnowBall());
    }

    IEnumerator ShootSnowBall()
    {
        while (true)
        {
            snowball = Instantiate(snowball, spawnPosOfSnowball.position, Quaternion.identity);
            snowball.Shoot(Vector2.right);
            yield return new WaitForSeconds(fireRate);
        }
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }

    public override void Interact(Player player)
    {
        // break down tower for parts
        print("Interact with tower: " + name);
    }

    public void Place(Player player)
    {
        // needs to know which player placed it for the direction
    }

    void Die()
    {

    }
}
