using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using static SW_List;

[ RequireComponent( typeof( SW_AnimationEvents ) ) ]
public class SelectionWheel : MonoBehaviour
{
    public enum SelectionMove { Left, Right, Up, Down };

    public enum VerticalOptions { Top, Bottom }

    public class SelectionConfig
    {
        public SW_List List;
        public int StartingItemI;
        public bool BottomOptionEnabled;
        public GameObject BottomOptionItem;

        public SelectionConfig (
            SW_List list,
            int startingItemI = 0,
            bool bottomOptionEnabled = false,
            GameObject bottomOptionItem = null ) 
        {
            this.List = list;
            this.StartingItemI = startingItemI;
            this.BottomOptionEnabled = bottomOptionEnabled;
            this.BottomOptionItem = bottomOptionItem;
        }
    }

    private enum States { Unshown, Idle, Moving };

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
        public SelectionConfig Config;
        public int ItemsI = 0;
        public int ItemSlotI = 0;
        public VerticalOptions verticalSelection = VerticalOptions.Top;

        public ActiveSelection( SelectionConfig config )
        {
            this.Config = config;
        }
    }

    [ SerializeField ]
    private float itemRadius = 2f;

    [SerializeField]
    private float itemSlotScale = 1f;

    [ SerializeField ]
    private uint wheelItemSlots = 6;

    [ SerializeField ]
    private float spinSpeed = 10f;

    [Tooltip( "The animation curve that the spin animation will have." )]
    [ SerializeField ]
    private AnimationCurve animationCurve;

    [Tooltip( "The amount of slots away from the top-most in which the new menu options will spawn in." )]
    [SerializeField]
    private uint slotSpawnDistance = 3;

    [ Tooltip( "The GameObject which will be a parent to the instantiated item containers." ) ]
    [ SerializeField ]
    private Transform itemSlotParent;

    [ Tooltip("The GameObject to rotate in order to spin the wheel.") ]
    [ SerializeField ]
    private Transform wheelRotate;

    [Tooltip("The GameObject which is a parent to all visible elements of the selection wheel.")]
    [ SerializeField ]
    private Transform visibleParent;

    [Tooltip("The GameObject to enable/disable to show/hide the bottom option.")]
    [SerializeField]
    private GameObject bottomOptionParent;

    [Tooltip("The bottom option's item slot.")]
    [SerializeField]
    private Transform bottomOptionItemSlot;

    [ SerializeField ]
    private GameObject dividerPrefab;

    [SerializeField]
    private Animator selectorAnimator;

    [ SerializeField ]
    private SW_SelectorAnimationEvents selectorAE;

    [ SerializeField ]
    private GameObject boGreyout;

    // Private / Unexposed fields //

    private Animator wheelAnimator;

    private SW_AnimationEvents wheelAE;

    private List< Transform > itemSlots = new List< Transform >();

    private ActiveSelection activeSelection = null;

    private States state = States.Unshown;

    private void Awake()
    {
        this.wheelAnimator = this.GetComponent<Animator>();
        this.wheelAE = this.GetComponent<SW_AnimationEvents>();
    }

    private void Start()
    {
        // Instantiate item slot GameObejcts.
        float slotAngleOffset = 360f / wheelItemSlots;

        // Create dividers.
        for (int i = 0; i < this.wheelItemSlots; i++)
        {
            float angle = (slotAngleOffset * i) + (slotAngleOffset / 2);

            float xNorm = Mathf.Sin(angle * Mathf.Deg2Rad);
            float yNorm = Mathf.Cos(angle * Mathf.Deg2Rad);

            var div = GameObject.Instantiate(this.dividerPrefab);

            div.transform.position = this.transform.position + new Vector3(xNorm, yNorm, 0) * this.itemRadius;

            div.transform.rotation = Quaternion.Euler(0, 0, -angle);

            div.transform.parent = this.itemSlotParent;

            // Set the divider's local position to 0.
            var oPos = div.transform.localPosition;
            div.transform.localPosition = new Vector3(oPos.x, oPos.y, 0);
        }

        // Create item slots.
        for (int i = 0; i < this.wheelItemSlots; i++)
        {
            float angle = slotAngleOffset * i;

            float xNorm = Mathf.Sin(angle * Mathf.Deg2Rad);
            float yNorm = Mathf.Cos(angle * Mathf.Deg2Rad);

            var slot = new GameObject("Item Slot");

            slot.transform.position = this.transform.position + new Vector3(xNorm, yNorm, 0) * this.itemRadius;

            // Set the rotation of the slots as they are around the center of the wheel.
            // (Angle needs to be negated to rotation in the proper direction.)
            slot.transform.rotation = Quaternion.Euler(0, 0, -angle);

            slot.transform.parent = this.itemSlotParent;

            // Set the slot's local position to 0.
            var oPos = slot.transform.localPosition;
            slot.transform.localPosition = new Vector3(oPos.x, oPos.y, 0);

            // Set the slot's scale to this.itemSlotScale.
            slot.transform.localScale = new Vector3(this.itemSlotScale, this.itemSlotScale, 1);

            this.itemSlots.Add(slot.transform);
        }

        this.setVisible(false);

        // Subscribe to the main wheel animator show/hide visible request event.
        this.wheelAE.OnHideVisibleRequested += () => { this.setVisible(false); };
        this.wheelAE.OnShowVisibleRequested += () => { this.setVisible(true); };

        // Subscribe to the selector finished move event to set our state back to idle.
        this.selectorAE.OnFinishedVertMoving += () =>
        {
            if (state == States.Moving)
            {
                this.state = States.Idle;
            }
        };
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, this.itemRadius);

        float slotAngleOffset = 360f / wheelItemSlots;

        for (int i = 0; i < this.wheelItemSlots; i++)
        {
            float xNorm = Mathf.Sin((slotAngleOffset * i) * Mathf.Deg2Rad);
            float yNorm = Mathf.Cos((slotAngleOffset * i) * Mathf.Deg2Rad);

            if (i == this.slotSpawnDistance || i == this.wheelItemSlots - this.slotSpawnDistance)
                Gizmos.color = Color.green;
            else
                Gizmos.color = Color.black;

            Gizmos.DrawWireSphere(transform.position + new Vector3(xNorm, yNorm, 0) * this.itemRadius, this.itemSlotScale / 2);
        }
    }

    /// <summary>
    /// Shows the wheel, given a particular configuration for the wheel for this new selection.
    /// </summary>
    /// <param name="config"></param>
    public void ShowWheel( SelectionConfig config )
    {
        this.activeSelection = new ActiveSelection( config );

        // Reset wheel orientation.
        this.wheelRotate.localRotation = Quaternion.Euler( 0, 0, 0 );

        Assert.IsTrue( config.StartingItemI < config.List.items.Length );

        this.activeSelection.ItemsI = config.StartingItemI;

        var sel = this.activeSelection;

        int minI = sel.ItemSlotI - (int)this.slotSpawnDistance;
        int maxI = sel.ItemSlotI + (int)this.slotSpawnDistance;

        for (int i = minI; i <= maxI; i++)
        {
            int slotIndex = WrapIndex( sel.ItemSlotI + i, this.itemSlots.Count );
            var parent = this.itemSlots[ slotIndex ];

            int itemsIndex = WrapIndex( sel.ItemsI + i, sel.Config.List.items.Length );
            // Create + place object.
            var vis = GameObject.Instantiate( sel.Config.List.items[itemsIndex].Visual );

            this.replaceItemSlotChild( parent, vis, SortingLayerReference.SW_Top );
        }

        // Show/Hide bottom option if configured.
        var hasBO = config.BottomOptionItem != null;

        this.bottomOptionParent.SetActive( hasBO );

        this.boGreyout.SetActive( !config.BottomOptionEnabled );

        if ( hasBO )
        {
            var vis = GameObject.Instantiate( config.BottomOptionItem );
            this.replaceItemSlotChild( this.bottomOptionItemSlot, vis, SortingLayerReference.SW_Bottom );
        }
        else 
        {
            // Remove all children in the bottomOptionSlot
            foreach (Transform c in this.bottomOptionItemSlot)
                GameObject.Destroy(c.gameObject);
        }

        // Trigger menu appearing animation.
        this.wheelAnimator.SetBool( "IsShown", true );

        // Reset selector animator to entry.
        this.selectorAnimator.SetBool( "TopSelected", true );
        this.selectorAnimator.Rebind();
        this.selectorAnimator.Update(0f);

        // Update state.
        this.state = States.Idle;
    }

    public void HideWheel()
    {
        // Trigger menu disappearing animation.
        this.wheelAnimator.SetBool( "IsShown", false );

        this.activeSelection = null;

        // Update state.
        this.state = States.Unshown;

        StopAllCoroutines();
    }

    public void Move( SelectionMove direction )
    {
        // Ignore move requests while there's no current selection.
        if ( this.state != States.Idle ) return;

        var sel = this.activeSelection;

        switch ( direction ) {
            case SelectionMove.Up:
                // If bottom is selected and we're requested to move up.
                if ( sel.verticalSelection == VerticalOptions.Bottom )
                {
                    sel.verticalSelection = VerticalOptions.Top;
                    this.state = States.Moving;
                    this.selectorAnimator.SetBool( "TopSelected", true );
                    break;
                }

                break;
            case SelectionMove.Down:
                // If bottom is selected and we're requested to move up.
                if (
                    sel.Config.BottomOptionEnabled &&
                    sel.verticalSelection == VerticalOptions.Top
                ) {
                    sel.verticalSelection = VerticalOptions.Bottom;
                    this.state = States.Moving;
                    this.selectorAnimator.SetBool( "TopSelected", false );
                    break;
                }

                break;

            case SelectionMove.Left: case SelectionMove.Right:
                // If the top is currently selected, rotate the wheel.
                if ( sel.verticalSelection == VerticalOptions.Top ) {
                    this.state = States.Moving;
                    StartCoroutine( this.spinMenu(direction) );
                }
                break;
        }
    }

    /// <summary>
    /// Returns a tuple representing the current selection, composed of:
    /// - The currently selected vertical option.
    /// - The selection value of the currently selected item.
    /// - The ItemI of the currently selected item.
    /// </summary>
    /// <returns>
    /// </returns>
    public ( VerticalOptions, object, int ) GetSelected()
    {
        Assert.IsNotNull( this.activeSelection );

        var sel = this.activeSelection;

        return ( sel.verticalSelection, sel.Config.List.items[sel.ItemsI].Value, sel.ItemsI );
    }

    private void setVisible( bool visible )
    {
        // Shows or hides all visible components of the selection wheel.
        foreach (var r in this.visibleParent.GetComponentsInChildren<Renderer>())
        {
            r.enabled = visible;
        }
    }

    /// <summary>
    /// Destroys any children of an item slot transform and places a gameobject instance as it's new only child.
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="go"></param>
    private void replaceItemSlotChild(Transform slot, GameObject go, string sortingLayer)
    {
        foreach (Transform c in slot)
            GameObject.Destroy(c.gameObject);

        var goTF = go.transform;

        goTF.parent = slot;

        goTF.localPosition = Vector3.zero;
        goTF.localRotation = Quaternion.Euler(0, 0, 0);
        goTF.localScale = Vector3.one;

        // Set all sprites to only show within a mask.
        foreach (var sr in goTF.GetComponentsInChildren<SpriteRenderer>()) {
            sr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            sr.sortingLayerName = sortingLayer;
        }
    }

    /// <summary>
    /// A coroutine to perform the animation for a menu rotation to the currently selected slot in this.activeSelection.
    /// </summary>
    /// <param name="itemSlot"></param>
    /// <returns></returns>
    private IEnumerator spinMenu( SelectionMove direction )
    {
        int offset = 0;

        switch ( direction ) {
            case SelectionMove.Left:
                offset = -1;
                break;
            case SelectionMove.Right:
                offset = 1;
                break;
            default:
                Assert.IsTrue( false ); // Raise an assert exception if we ever get here.
                // Exit coroutine if either up or down is passed in.
                yield break;
        }

        var sel = this.activeSelection;
        var origSlot = sel.ItemSlotI;
        var targetSlot = WrapIndex(sel.ItemSlotI + offset, this.itemSlots.Count);

        var anglePerSlot = 360f / wheelItemSlots;

        var eulerTargetRot = targetSlot * anglePerSlot;

        // Get the original and target rotations as quaternions.
        var originalRot = this.wheelRotate.localRotation;
        var targetRot = Quaternion.Euler( new Vector3( 0, 0, eulerTargetRot ) );

        // Advance the selection's index.
        sel.ItemsI = WrapIndex(sel.ItemsI + offset, sel.Config.List.items.Length);
        sel.ItemSlotI = WrapIndex(sel.ItemSlotI + offset, this.itemSlots.Count);

        float t = 0f; // Current time of spin animation from 0 - 1.

        // Run animation until finished.
        while ( t <= 1f ) {
            var animT = this.animationCurve.Evaluate( t );

            this.wheelRotate.localRotation = Quaternion.Slerp( originalRot, targetRot, animT );

            t += this.spinSpeed * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        // Spawn the next items at the slots that are this.slotSpawnDistance away from the currently selected.
        var spawnDist = (int)this.slotSpawnDistance;

        // Left
        var lSlot        = this.itemSlots[WrapIndex(sel.ItemSlotI - spawnDist, this.itemSlots.Count)];
        var lSlotItemPre = sel.Config.List.items[WrapIndex(sel.ItemsI - spawnDist, sel.Config.List.items.Length)].Visual;
        var lSlotItemGO  = GameObject.Instantiate( lSlotItemPre );

        this.replaceItemSlotChild( lSlot, lSlotItemGO, SortingLayerReference.SW_Top );

        // Right
        var rSlot = this.itemSlots[WrapIndex(sel.ItemSlotI + spawnDist, this.itemSlots.Count)];
        var rSlotItemPre = sel.Config.List.items[WrapIndex(sel.ItemsI + spawnDist, sel.Config.List.items.Length)].Visual;
        var rSlotItemGO = GameObject.Instantiate(rSlotItemPre);

        this.replaceItemSlotChild( rSlot, rSlotItemGO, SortingLayerReference.SW_Top );

        this.state = States.Idle;
    }
}
