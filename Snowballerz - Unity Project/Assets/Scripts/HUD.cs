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

    [Header("Player 1 Elements")]
    public Text ScoreText;
    public Text ResourceText;
    public UIRadio ToolSelector;

    void Start()
    {
        //Get the player, for now just one, and assign its resource count change function to the hud's.
        Player.OnSnowCountChange += UpdateResourceCount;

        //We should just be at 0 at start, so we can just run this and others after.
        UpdateResourceCount(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateResourceCount(int resourceCount)
    {
        ResourceText.text = resourceCount.ToString();
    }

}
