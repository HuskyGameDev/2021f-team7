using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Assertions;

enum HealthState
{
    FullyHealed,
    Damaged,
    AlmostDestroyed
}

public class Tower : GridObject, IDamageable, IDirectionable
{
    // Snowball that the tower shoots
    [ SerializeField ]
    SnowBall snowball;

    [ SerializeField ]
    new string name;

    public SpriteRenderer sprite;

    // Its only set to true temporarly. Later we need to know which direction player 1 and 2 is facing
    //bool facingRight = true;

    Vector2 targetDirection = Vector2.left;

    [ SerializeField ]
    int health;

    int Health
    {
        get { return health; }

        set
        {
            if (value <= 0)
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

    [ SerializeField ]
    int fireRate;

    /// <summary>
    /// A transform which contains all of the main gameobjects of the tower, who has
    /// an normal (1, 1, 1) scale that will be inverted to flip the tower,
    /// depending on it's target direction.
    /// </summary>
    [ SerializeField ]
    Transform pivot;

    // this will be different for every tower because they are not all the same width and height
    [ SerializeField ]
    Transform spawnPosOfSnowball;

    Dictionary< HealthState, Sprite > towerSprites = new Dictionary< HealthState, Sprite >();

    bool placed;

    public bool Placed
    {
        get { return placed; }

        set 
        {
            value = placed;
        }
    }

    public GameObject Object
    {
        get { return this.gameObject; }
    }

    bool isBurned;

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
            sb.Shoot( this.targetDirection );
            yield return new WaitForSeconds(fireRate);
        }
    }

    public void TakeDamage( int amount )
    {
        Health -= amount;
    }

    public override void Interact( Player player )
    {
        Debug.Log( "Interact with tower: " + name );
    }

    void Die()
    {
        // anything else
        Destroy(gameObject);
    }

    /// <summary>
    /// Sets the target direction of the tower.
    /// Assumes that the input is a non-zero, normalized value.
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection( Vector2 direction )
    {
        this.targetDirection = direction;

        var scale = this.pivot.localScale;

        // Flip object x scale depending on the direction.
        // Right
        if (direction.x > 0)
        {
            scale.x = 1;
        }
        // Left
        else if (direction.x < 0)
        {
            scale.x = -1;
        }
        // If x direction is zero.
        else
        {
            Debug.LogError(
                "Tower's provided direction has a zero x Vector component! " +
                "Cannot determine the horizontal direction for the tower to face.");
            Assert.IsTrue(false);
        }

        this.pivot.localScale = scale;
    }
}