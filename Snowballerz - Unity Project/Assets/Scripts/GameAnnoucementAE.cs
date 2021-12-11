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

    public void ExitScene( )
    {
        this.mc.ExitScene();
    }
}
