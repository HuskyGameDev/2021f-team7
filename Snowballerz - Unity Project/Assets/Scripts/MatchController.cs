using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    [ SerializeField ]
    private MapGrid map;
    
    private void Awake()
    {
        
    }

    private void Start()
    {
        // Subscribe each flag in each line to 
        foreach ( var line in map.Lines )
        {
            Action flagDeath = () => {
                // Destroy flags.
                Destroy( line.P1Flag.gameObject );
                Destroy( line.P2Flag.gameObject );

                foreach ( var gs in line.P1.Concat( line.P2 ) )
                {
                    var go = gs.RemoveGridObject();

                    if ( go != null )
                        GameObject.Destroy( go.gameObject );

                    gs.State = GridSquare.GSState.Unplaceable;
                }
            };

            line.P1Flag.OnFlagDeath += flagDeath;
            line.P2Flag.OnFlagDeath += flagDeath;
        }
    }
}
