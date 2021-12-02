using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using System.Collections.Generic;
using UnityEditor;

public class Tower : GridObject, IDamageable, IDirectionable
{
    // Snowball that the tower shoots
    [ SerializeField ]
    SnowBall snowball;

    [ SerializeField ]
    new string name;

    public List<SpriteRenderer> srs = new List<SpriteRenderer>();

    Vector2 targetDirection = Vector2.left;

    [ SerializeField ]
    int health;

    int Health
    {
        get { return health; }

        set
        {
            health = value;

            if ( health <= 0 )
            {
                health = 0;
                Die();
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

    void Awake()
    {
        this.srs.AddRange( this.GetComponentsInChildren<SpriteRenderer>() );
    }

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

            //if (sb.gameObject.GetComponent<BombSnowball>() != null)
            //{
            //    sb.gameObject.GetComponent<BombSnowball>().bombCollider.layer = this.gameObject.layer;
            //}

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
        Destroy(gameObject);
    }

    /// <summary>
    /// Sets the target direction of the tower.
    /// Assumes that the input is a non-zero, normalized value.
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(Vector2 direction)
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

    private void OnDrawGizmos()
    {
        DebugUtils.DrawString( this.health.ToString(), transform.position, -10, 0, Color.red );
    }
}