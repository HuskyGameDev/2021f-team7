using UnityEngine;

public class SnowBall : MonoBehaviour
{
    float speed;
    int damage;

    void Update()
    {
        gameObject.transform.Translate(Vector2.right);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }
}