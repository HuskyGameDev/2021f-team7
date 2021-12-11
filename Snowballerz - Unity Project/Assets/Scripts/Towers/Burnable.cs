using System.Collections;
using UnityEngine;

public class Burnable : MonoBehaviour
{
    [ SerializeField ]
    private Vector3 flamesOffset;
    
    [ SerializeField ]
    private GameObject flamesEffect;

    private GameObject activeFlamesEffect;
    
    int burnDamage = 5;
    float burnTimer = 1.5f;

    IDamageable tower;

    bool isBurned = false;

    Coroutine burnCoroutine;
    Coroutine burnTimerCoroutine;

    void Start()
    {
        tower = GetComponent<IDamageable>();   
    }

    public void StartBurn()
    {
        if (this.burnTimerCoroutine != null)
        {
            StopCoroutine(this.burnTimerCoroutine);
            this.burnTimerCoroutine = null;
        }
        if (this.burnCoroutine != null)
        {
            StopCoroutine(this.burnCoroutine);
            this.burnCoroutine = null;
        }
        
        this.burnTimerCoroutine = StartCoroutine( BurnTimer( 3f ) );
    }

    IEnumerator BurnTimer( float time )
    {
        // Add flames effect if it's not currently on.
        if ( this.activeFlamesEffect == null )
        {
            this.activeFlamesEffect = GameObject.Instantiate(this.flamesEffect, this.transform);
            this.activeFlamesEffect.transform.localPosition = this.flamesOffset;
        }

        this.burnCoroutine = StartCoroutine( Burn() );

        yield return new WaitForSeconds( time );

        if (this.burnCoroutine != null)
        {
            StopCoroutine(this.burnCoroutine);
            this.burnCoroutine = null;
        }

        if ( this.activeFlamesEffect != null )
        {
            Destroy( this.activeFlamesEffect );
            this.activeFlamesEffect = null;
        }
    }

    IEnumerator Burn()
    {   
        while( true )
        {
            yield return new WaitForSeconds(burnTimer);
            tower.TakeDamage(burnDamage);
        }
    }
}