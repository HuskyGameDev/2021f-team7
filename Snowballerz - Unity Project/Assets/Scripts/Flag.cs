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

    public int Health 
    {
        get
        {
            return this.health;
        }
        set
        {
            if ( value <= 0 )
            {
                this.health = 0;

                this.Die();
            }
            else 
            {
                this.health = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

        GameObject.Destroy( this.gameObject );
    }
}
