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
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        
        if ( damageable != null )
        {
            damageable.TakeDamage(damage);

            // many things can happen when a snowball gets destroyed
            // sound effect
            // partice effect
            Destroy( this.gameObject );
        }
    }
}