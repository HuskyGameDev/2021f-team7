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

    [ SerializeField ]
    int health;

    [ SerializeField ]
    GameObject explosionEffect;

    [ SerializeField ]
    SpriteRenderer spriteRenderer;

    [ SerializeField ]
    Sprite[] damageSprites;

    [ SerializeField ]
    private AudioSource shootSFX;

    List<SpriteRenderer> srs = new List<SpriteRenderer>();

    Vector2 targetDirection = Vector2.left;

    int initialHealth;

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

            this.updateSprite();
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

    public GameObject Object
    {
        get { return this.gameObject; }
    }

    bool isBurned;

    void Awake()
    {
        this.srs.AddRange( this.GetComponentsInChildren<SpriteRenderer>() );

        this.initialHealth = this.health;
    }

    void Start()
    {
        this.updateSprite();
        
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

            this.shootSFX.Play();

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
        // Spawn an explosion effect.
        var explosion = GameObject.Instantiate( this.explosionEffect );

        explosion.transform.position = this.transform.position;

        Destroy( this.gameObject );
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

    private void updateSprite()
    {
        var progress = 1 - (float)this.health / (float)this.initialHealth;

        int spriteI = (int)( (float)this.damageSprites.Length * progress );
        // Limit spriteI to be below damageSprite.Length.
        spriteI = Mathf.Min( spriteI, this.damageSprites.Length - 1 );

        this.spriteRenderer.sprite = this.damageSprites[ spriteI ];
    }

    private void OnDrawGizmos()
    {
        #if UNITY_EDITOR
                DebugUtils.DrawString( this.health.ToString(), transform.position, -10, 0, Color.red );
        #endif
    }
}