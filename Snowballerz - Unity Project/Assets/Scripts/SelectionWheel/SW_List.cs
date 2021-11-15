using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public struct SW_Item
{
    [ Tooltip("A GameObject prefab to be instantiated to be used for the selectionwheel item's visuals.") ]
    public GameObject Visual;
    [ Tooltip("A generic object reference to represent an useful identifier / value for a selected item.") ]
    public object Value;
}

[ System.Serializable ]
public struct SW_List
{
    [ Tooltip("An array of GameObject prefabs to be instantiated to be used as SelectionWheel menu items.") ]
    public SW_Item[] items;

    public SW_List( SW_Item[] items ) 
    {
        this.items = items;
    }
}
