using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static SelectionWheelList;

public class SelectionWheel : MonoBehaviour
{
    public enum SelectionMove { Left, Right };

    // Big thanks to Charles Bailey from StackOverflow for the proper
    // Positive-negative wrapping function:
    // https://stackoverflow.com/a/707426/7782953
    private static int WrapIndex( int i, int size )
    {
        Assert.IsTrue( size > 0 );

        var lowerBound = 0;
        var upperBound = size - 1;

        int range_size = upperBound - lowerBound + 1;

        if ( i < lowerBound )
            i += range_size * ( (lowerBound - i) / range_size + 1 );

        return lowerBound + ( i - lowerBound ) % range_size;
    }

    private class ActiveSelection
    {
        public SelectionWheelList list;
        public int itemsI = 0;
        public int itemSlotI = 0;

        public ActiveSelection( SelectionWheelList list )
        {
            this.list = list;
        }
    }

    [ SerializeField ]
    private float itemRadius = 2f;

    [SerializeField]
    private float itemSlotScale = 1f;

    [ SerializeField ]
    private uint wheelItemSlots = 6;

    [Tooltip("The amount of slots away from the top-most in which the new menu options will spawn in.")]
    [SerializeField]
    private uint slotSpawnDistance = 3;

    [ Tooltip( "The gameobject which will be a parent to the instantiated item containers." ) ]
    [ SerializeField ]
    private Transform itemSlotParent;

    private List< Transform > itemSlots = new List< Transform >();

    private ActiveSelection activeSelection = null;

    // Show the wheel using a particular SelectionWheelList.
    public void ShowWheel( SelectionWheelList list )
    {
        this.activeSelection = new ActiveSelection(list);

        var sel = this.activeSelection;

        int minI = sel.itemSlotI - (int)this.slotSpawnDistance;
        int maxI = sel.itemSlotI + (int)this.slotSpawnDistance;

        for (int i = minI; i <= maxI; i++)
        {
            int slotIndex = WrapIndex( sel.itemSlotI + i, this.itemSlots.Count );
            var parent = this.itemSlots[ slotIndex ];

            int itemsIndex = WrapIndex( sel.itemsI + i, sel.list.items.Length );
            var itemVisual = GameObject.Instantiate( sel.list.items[ itemsIndex ].Visual, parent );
        }

    }

    public void Move( SelectionMove direction )
    {

    }

    void Start()
    {
        // Instantiate item slot GameObejcts.
        float slotAngleOffset = 360f / wheelItemSlots;

        for ( int i = 0; i < this.wheelItemSlots; i++ )
        {
            float angle = slotAngleOffset * i;

            float xNorm = Mathf.Sin( angle * Mathf.Deg2Rad );
            float yNorm = Mathf.Cos( angle * Mathf.Deg2Rad );

            var slot = new GameObject( "Item Slot" );

            slot.transform.position = this.transform.position + new Vector3( xNorm, yNorm, 0 ) * this.itemRadius;

            // Set the rotation of the slots as they are around the center of the wheel.
            // (Angle needs to be negated to rotation in the proper direction.)
            slot.transform.rotation = Quaternion.Euler( 0, 0, -angle );

            slot.transform.parent = this.itemSlotParent;

            // Set the slot's local position to 0.
            var oPos = slot.transform.localPosition;
            slot.transform.localPosition = new Vector3(oPos.x, oPos.y, 0);

            // Set the slot's scale to this.itemSlotScale.
            slot.transform.localScale = new Vector3( this.itemSlotScale, this.itemSlotScale, 1 );

            this.itemSlots.Add( slot.transform );
        }
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, this.itemRadius );

        float slotAngleOffset = 360f / wheelItemSlots;

        for ( int i = 0; i < this.wheelItemSlots; i++ ) {
            float xNorm = Mathf.Sin( ( slotAngleOffset * i ) * Mathf.Deg2Rad);
            float yNorm = Mathf.Cos( ( slotAngleOffset * i ) * Mathf.Deg2Rad);

            if ( i == this.slotSpawnDistance || i == this.wheelItemSlots - this.slotSpawnDistance )
                Gizmos.color = Color.green;
            else
                Gizmos.color = Color.black;

            Gizmos.DrawWireSphere( transform.position + new Vector3( xNorm, yNorm, 0 ) * this.itemRadius , this.itemSlotScale / 2 );
        }
    }
}
