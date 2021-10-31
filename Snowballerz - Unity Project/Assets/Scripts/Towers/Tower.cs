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
            var sb = Instantiate(snowball, spawnPosOfSnowball.position, Quaternion.identity);
            // Set the snowball to be on the same player collision layer as us, as to not collide with any of our own towers.
            sb.gameObject.layer = this.gameObject.layer;
            sb.Shoot(Vector2.right);
            yield return new WaitForSeconds(fireRate);
        }
    }

    void IDamageable.TakeDamage( int amount )
    {
        this.health = Mathf.Max( this.health - amount, 0 );

        if ( this.health == 0 ) {
            Debug.Log( "Tower destroyed!" );
            GameObject.Destroy( this.gameObject );
        }
    }

    public override void Interact( Player player )
    {
        Debug.Log( "Interact with tower: " + name );
    }

    public void DefinePlayer( Player player )
    {
        // needs to know which player placed it for the direction
    }

    void Die()
    {

    }
}
