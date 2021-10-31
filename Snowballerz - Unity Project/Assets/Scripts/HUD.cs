using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 Acts basically as a control class for the hud.
 */

namespace Snoballerz.UI
{
    public class HUD : MonoBehaviour
    {
        // Start is called before the first frame update
        //Todo: Alex is there a better way to organize?

        public enum plytype
        {
            PLAYER_1,
            PLAYER_2
        }

        [Header("Player 1 Elements")]
        public Text ScoreTextOne;
        public Text ResourceTextOne;
        public UiCounter WeaponAmmoOne;

        [Header("Player 2 Elements")]
        public Text ScoreTextTwo;
        public Text ResourceTextTwo;
        public UiCounter WeaponAmmoTwo;

        [Header("Timer")]
        public Timer timer;

        void Start()
        {

            //Get the player, for now just one, and assign its resource count change function to the hud's.
            Player.OnSnowCountChange += UpdateResourceCount;

            Player.OnScoreChanged += UpdateScore;

            //We should just be at 0 at start, so we can just run this and others after.
            UpdateResourceCount(0, plytype.PLAYER_1);
            UpdateResourceCount(0, plytype.PLAYER_2);

            UpdateScore(0, plytype.PLAYER_1);
            UpdateScore(0, plytype.PLAYER_2);

        }

        // Update is called once per frame
        void Update()
        {

        }

        public int GetResourceCount(plytype plyID)
        {
            switch (plyID)
            {
                case plytype.PLAYER_2:
                    return int.Parse(ResourceTextTwo.text);
                default:
                    return int.Parse(ResourceTextOne.text);
            }
        }

        void UpdateResourceCount(int resourceCount, plytype plyID)
        {
            switch (plyID)
            {
                case plytype.PLAYER_2:
                    ResourceTextTwo.text = resourceCount.ToString();
                    WeaponAmmoTwo.snowballs.Count = resourceCount;
                    break;
                default:
                    ResourceTextOne.text = resourceCount.ToString();
                    WeaponAmmoOne.snowballs.Count = resourceCount;
                    break;
            }
            //ResourceText.text = resourceCount.ToString();
        }

        void UpdateScore(uint score, plytype plyID)
        {
            switch (plyID)
            {
                case plytype.PLAYER_2:
                    ScoreTextTwo.text = score.ToString();
                    break;
                default:
                    ScoreTextOne.text = score.ToString();
                    break;
            }
        }

    }
}