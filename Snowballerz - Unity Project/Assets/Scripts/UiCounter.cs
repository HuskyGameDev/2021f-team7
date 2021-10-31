using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Snoballerz.UI.HUD;

namespace Snoballerz.UI {
    public class UiCounter : MonoBehaviour
    {

        public plytype plyId;
        public SnowballCount snowballs;
        public List<Equipment> _equipment;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //Todo, formulate this in a more object oriented sense.
        public void AddEquipment()
        {
            //Add an equipment to the list
            Equipment equip = new Equipment();
            Instantiate(equip);
        }

        public void RemoveEquipment(Equipment equip)
        {
            //Remove equipment from the list and make it invis.
        }

    }
}
