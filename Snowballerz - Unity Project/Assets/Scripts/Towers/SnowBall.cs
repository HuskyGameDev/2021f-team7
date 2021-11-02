using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    int damage;

    bool wasShot;

    Vector2 direction;

    private Rigidbody2D rb;

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (wasShot == true)
        {
            this.rb.position += direction * speed * Time.deltaTime;
        }
    }

    public void Shoot(Vector2 directionToShoot)
    {
        direction = directionToShoot;
        wasShot = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent< IDamageable >();
        
        if ( damageable != null )
        {
            damageable.TakeDamage( damage );

            // many things can happen when a snowball gets destroyed
            // sound effect
            // partice effect
            Destroy( this.gameObject );
        }
    }
}