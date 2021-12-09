using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    [ SerializeField ]
    private MapGrid map;

    [ SerializeField ]
    private Player p1;
    [ SerializeField ]
    private Player p2;

    [ SerializeField ]
    private Animator gameAnnoucementAnim;

    [ SerializeField ]
    private GameObject explosionEffect;

    private void Start()
    {
        // Subscribe each flag in each line to 
        foreach ( var line in map.Lines )
        {
            Action flagDeath = () => {
                // Destroy flags.
                Destroy( line.P1Flag.gameObject );
                Destroy( line.P2Flag.gameObject );

                // Place explosion effect for flags.
                GameObject.Instantiate( this.explosionEffect, line.P1Flag.transform.position, Quaternion.Euler( 0, 0, 0 ) );
                GameObject.Instantiate( this.explosionEffect, line.P2Flag.transform.position, Quaternion.Euler( 0, 0, 0 ) );

                foreach ( var gs in line.P1.Concat( line.P2 ) )
                {
                    var go = gs.RemoveGridObject();

                    if ( go != null )
                        GameObject.Destroy( go.gameObject );

                    gs.State = GridSquare.GSState.Unplaceable;

                    // Place explosion effect on GridSquare.
                    GameObject.Instantiate( this.explosionEffect, gs.transform.position, Quaternion.Euler( 0, 0, 0 ) );
                }
            };

            line.P1Flag.OnFlagDeath += flagDeath;
            line.P2Flag.OnFlagDeath += flagDeath;
        }

        // Initialize both players to be disabled.
        this.p1.enabled = false;
        this.p2.enabled = false;

        // Flip player 2 to face left.
        this.p2.GetComponent<Animator>().SetBool("FacingRight", false);

        // Start the StartGame animation after 1 second.
        StartCoroutine( StartGameAnimationDelay( 1f ) ) ;
    }

    public void StartGame()
    {
        // Enable both players.
        this.p1.enabled = true;
        this.p2.enabled = true;
    }

    public void EndGame()
    {
        // Disable both players.
        this.p1.enabled = false;
        this.p2.enabled = false;
    }

    private IEnumerator StartGameAnimationDelay( float t )
    {
        yield return new WaitForSeconds( t );

        this.gameAnnoucementAnim.SetTrigger( "StartGame" );
    }
}
