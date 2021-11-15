using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class PlayerInputWrapper
{
    public enum Players { Player_1, Player_2 };

    public enum Actions { Move, Action, Select, Snowball, SelectDirection };

    public static InputAction GetInputAction( InputActions ia, Actions action, Players player )
    {
        InputAction ret = null;

        switch ( action ) {
            case Actions.Move:
                if (player == Players.Player_1)
                    ret = ia.Player_1.Move;
                else
                    ret = ia.Player_2.Move;
                break;
            case Actions.Action:
                if (player == Players.Player_1)
                    ret = ia.Player_1.Action;
                else
                    ret = ia.Player_2.Action;
                break;
            case Actions.Select:
                if (player == Players.Player_1)
                    ret = ia.Player_1.Select;
                else
                    ret = ia.Player_2.Select;
                break;
            case Actions.Snowball:
                if (player == Players.Player_1)
                    ret = ia.Player_1.Snowball;
                else
                    ret = ia.Player_2.Snowball;
                break;
            case Actions.SelectDirection:
                if (player == Players.Player_1)
                    ret = ia.Player_1.SelectDirection;
                else
                    ret = ia.Player_2.SelectDirection;
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
