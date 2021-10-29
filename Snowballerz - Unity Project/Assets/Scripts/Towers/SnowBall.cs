using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    int damage;

    bool wasShot;

    Vector2 direction;

    void Update()
    {
        if (wasShot == true)
        {
            gameObject.transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void Shoot(Vector2 directionToShoot)
    {
        direction = directionToShoot;
        wasShot = true;
        Destroy(gameObject, 5.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damage);

            // many things can happen when a snowball gets destroyed
            // sound effect
            // partice effect
            Destroy(gameObject);
        }
    }
}