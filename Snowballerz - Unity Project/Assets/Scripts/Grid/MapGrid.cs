using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MapGrid : MonoBehaviour
{
    public enum Players { Player_1, Player_2 };

    [ System.Serializable ]
    public struct Line
    {
        public GridSquare[] P1;
        public GridSquare[] P2;
    }

    [ SerializeField ]
    private Line[] lines;
    public Line[] Lines => lines;

    /// <summary>
    /// Get a line's GridSquare array for a particular player.
    /// </summary>
    /// <param name="line"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    public static GridSquare[] GetForPlayer ( Line line, Players player ) 
    {
        GridSquare[] ret = null;

        switch ( player ) {
            case Players.Player_1:
                ret = line.P1;
                break;
            case Players.Player_2:
                ret = line.P2;
                break;
            default:
                // Fail an assertion; 
                // we should never get here since every case should be implemented.
                Assert.IsTrue( false );
                break;
        }

        return ret;
    }

}
