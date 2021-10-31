using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Snoballerz.UI.HUD;

namespace Snoballerz.UI
{
    public class Equipment : MonoBehaviour
    {

        public plytype plyId;
        public Text CountText;
        public Image _background;
        public Image _foreground;

        [SerializeField]
        private int count;

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                CountText.text = count.ToString();
            }
        }

        public void Start()
        {
            Count = 0;
        }

        public void Update()
        {

        }

    }
}