using UnityEngine;

public abstract class SnowBall : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    int damage;

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

    public void Shoot(Vector2 directionToShoot)
    {
        direction = directionToShoot;
        wasShot = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        
        if (damageable != null)
        {
            //damageable.TakeDamage(damage);
            DoDamage(damageable);
            // many things can happen when a snowball gets destroyed
            // sound effect
            // partice effect
            Destroy(gameObject);
        }
    }

    protected abstract void DoDamage(IDamageable obj);
}