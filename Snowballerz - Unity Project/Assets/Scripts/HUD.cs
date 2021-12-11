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
        //We should just be at 0 at start, so we can just run this and others after.
        SetP1SnowCount( 0 );
        SetP2SnowCount( 0 );

        SetP1DestroyedFlagCount( 0 );
        SetP2DestroyedFlagCount( 0 );
    }

    public void SetP1SnowCount(int count)
    {
        this.P1ResourceText.text = count.ToString();
    }

    public void SetP2SnowCount(int count)
    {
        this.P2ResourceText.text = count.ToString();
    }

    public void SetP1DestroyedFlagCount(int count)
    {
        this.P1ScoreText.text = count.ToString();
    }

    public void SetP2DestroyedFlagCount(int count)
    {
        this.P2ScoreText.text = count.ToString();
    }

}
