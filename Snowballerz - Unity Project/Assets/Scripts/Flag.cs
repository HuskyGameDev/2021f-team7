using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour, IDamageable
{

    public Sprite[] flagStates;

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
}
