using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAnnoucementAE : MonoBehaviour
{
    [ SerializeField ]
    private MatchController mc;
    
    /// <summary>
    /// Called by an animation event to start the game.
    /// </summary>
    public void StartGame( )
    {
        this.mc.StartGame();
    }

    /// <summary>
    /// Called by an animation event to end the game.
    /// </summary>
    public void EndGame()
    {
        this.mc.EndGame();
    }
}
