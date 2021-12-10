using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour, IDamageable
{

    public Sprite[] flagStates;

    public event Action OnFlagDeath;

    [ SerializeField ]
    private int health = 100;

    [ SerializeField ]
    private GameObject explosionEffect;

    [ SerializeField ]
    private SpriteRenderer spriteRenderer;

    [ SerializeField ]
    private Sprite[] damageSprites;

    private int initialHealth;

    public int Health 
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = value;
            
            if ( this.health <= 0 )
            {
                this.health = 0;
                this.Die();
            }

            this.updateSprite();
        }
    }

    void Awake()
    {
        this.initialHealth = this.health;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.updateSprite();
    }

    // IDamageable Implementation: //
    public GameObject Object => this.gameObject;

    public void TakeDamage(int amount)
    {
        this.Health -= amount;
    }

    public void Die( )
    {
        if ( this.OnFlagDeath != null )
        {
            this.OnFlagDeath.Invoke();
        }

        var explosion = GameObject.Instantiate( this.explosionEffect );

        explosion.transform.position = this.transform.position;

        GameObject.Destroy( this.gameObject );
    }

    private void updateSprite()
    {
        var progress = 1 - (float)this.health / (float)this.initialHealth;

        int spriteI = (int)((float)this.damageSprites.Length * progress);
        // Limit spriteI to be below damageSprite.Length.
        spriteI = Mathf.Min(spriteI, this.damageSprites.Length - 1);

        this.spriteRenderer.sprite = this.damageSprites[spriteI];
    }
}
