using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    protected int damage;

    bool wasShot;

    Vector2 direction;

    Rigidbody2D rb;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (wasShot == true)
        {
            rb.position += direction * speed * Time.deltaTime;
        }
    }

    public void Shoot( Vector2 directionToShoot )
    {
        direction = directionToShoot;
        wasShot = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        
        if (damageable != null)
        {
            DoDamage(damageable);

            // sound effect
            // partice effect
            Destroy(gameObject);
        }
    }

    // this function will be overwritten for each special snowball
    protected virtual void DoDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }
}