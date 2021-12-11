using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchController : MonoBehaviour
{
    [ SerializeField ]
    private MapGrid map;

    [ SerializeField ]
    private HUD hud;

    [ SerializeField ]
    private Player p1;
    [ SerializeField ]
    private Player p2;

    [ SerializeField ]
    private Animator gameAnnoucementAnim;

    [ SerializeField ]
    private GameObject explosionEffect;

    private bool gameRunning = false;

    /// <summary>
    /// The amount of flags destroyed by Player 1.
    /// </summary>
    private int p1DestroyedFlags = 0;

    /// <summary>
    /// The amount of flags destroyed by Player 2.
    /// </summary>
    private int p2DestroyedFlags = 0;

    private void Start()
    {
        // Subscribe each flag in each line to 
        foreach ( var line in map.Lines )
        {
            Action flagDeath = ( ) => {
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

            Action P1FlagDeath = flagDeath;

            P1FlagDeath += () =>
            {
                this.p2DestroyedFlags++;

                this.hud.SetP2DestroyedFlagCount( this.p2DestroyedFlags );
            };

            Action P2FlagDeath = flagDeath;

            P2FlagDeath += () =>
            {
                this.p1DestroyedFlags++;

                this.hud.SetP1DestroyedFlagCount( this.p1DestroyedFlags );
            };

            Action WinDetermine = () =>
            {
                if ( !this.gameRunning )
                    return;
                
                // If P1 won.
                if ( this.p1DestroyedFlags >= 3 )
                {
                    this.EndGame();

                    this.gameAnnoucementAnim.SetInteger( "WinningPlayer", 1 );
                    this.gameAnnoucementAnim.SetTrigger( "GameFinish" );
                }
                // If p2 won.
                else if ( this.p2DestroyedFlags >= 3 )
                {
                    this.EndGame();

                    this.gameAnnoucementAnim.SetInteger( "WinningPlayer", 2 );
                    this.gameAnnoucementAnim.SetTrigger( "GameFinish" );
                }
                // If tie.
                else if ( this.p1DestroyedFlags == 2 && this.p2DestroyedFlags == 2 )
                {
                    this.EndGame();

                    this.gameAnnoucementAnim.SetInteger( "WinningPlayer", 0 );
                    this.gameAnnoucementAnim.SetTrigger( "GameFinish" );
                }
            };

            P1FlagDeath += WinDetermine;
            P2FlagDeath += WinDetermine;

            line.P1Flag.OnFlagDeath += P1FlagDeath;
            line.P2Flag.OnFlagDeath += P2FlagDeath;
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

        this.gameRunning = true;
    }

    public void EndGame()
    {
        // Disable both players.
        this.p1.enabled = false;
        this.p2.enabled = false;

        this.gameRunning = false;
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    private IEnumerator StartGameAnimationDelay( float t )
    {
        yield return new WaitForSeconds( t );

        this.gameAnnoucementAnim.SetTrigger( "StartGame" );
    }
}
