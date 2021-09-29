using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    int damage;

    [HideInInspector]
    public bool isFacingRight;

    void Update()
    {
        if (isFacingRight == true)
        {
            gameObject.transform.Translate(Vector2.right);
        }
        else
        {
            gameObject.transform.Translate(Vector2.left);
        }
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