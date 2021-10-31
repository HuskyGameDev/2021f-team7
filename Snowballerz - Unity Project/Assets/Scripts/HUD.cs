using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 Acts basically as a control class for the hud.
 */
public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    //Todo: Alex is there a better way to organize?

    public Player player1;
    public Player player2;

    [Header("Player 1 Elements")]
    public Text    P1ScoreText;
    public Text    P1ResourceText;
    public UIRadio P1ToolSelector;

    [Header("Player 2 Elements")]
    public Text    P2ScoreText;
    public Text    P2ResourceText;
    public UIRadio P2ToolSelector;

    void Start()
    {
        //Get the player, for now just one, and assign its resource count change function to the hud's.
        player1.OnSnowCountChange += P1UpdateResourceCount;
        player2.OnSnowCountChange += P2UpdateResourceCount;

        //We should just be at 0 at start, so we can just run this and others after.
        P1UpdateResourceCount(0);
        P2UpdateResourceCount(0);

    }

    void P1UpdateResourceCount( int resourceCount  )
    {
        P1ResourceText.text = resourceCount.ToString();
    }

    void P2UpdateResourceCount( int resourceCount )
    {
        P2ResourceText.text = resourceCount.ToString();
    }

}
