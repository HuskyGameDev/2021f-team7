using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SW_Item
{
    [ Tooltip("A GameObject prefab to be instantiated to be used for the selectionwheel item's visuals.") ]
    public GameObject Visual;
    [ Tooltip("An 0 or positive integer to identify the wheel item to.") ]
    public int ID;
}

[ System.Serializable ]
public struct SW_List
{
    [ Tooltip("An array of GameObject prefabs to be instantiated to be used as SelectionWheel menu items.") ]
    public SW_Item[] items;
}
