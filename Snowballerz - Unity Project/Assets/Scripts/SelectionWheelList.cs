using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionWheelList : MonoBehaviour
{
    [ System.Serializable ]
    public struct SelectionWheelItem
    {
        [ Tooltip("A GameObject prefab to be instantiated to be used for the selectionwheel item's visuals.") ]
        public GameObject Visual;
        [ Tooltip("An integer to identify the wheel item to.") ]
        public int ID;
    }

    [ Tooltip("An array of GameObject prefabs to be instantiated to be used as SelectionWheel menu items.") ]
    public SelectionWheelItem[] items;
}
