///
/// Based off of code by eshan-mathur from the Unity forums.
/// Source: https://forum.unity.com/threads/manually-trigger-navigation-events-in-script.874213/
///

using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventSystem))]
public class EventSystemInjector : MonoBehaviour
{
    EventSystem eventSystem;

    private void Awake()
    {
        eventSystem = GetComponent<EventSystem>();

        var input = GlobalInputActions.Instance;

        input.Player_1.Move.performed += ctx =>
        {
            var vec = ctx.ReadValue< Vector2 >();

            if (vec.y > 0)
                this.Move( MoveDirection.Up );
            else if (vec.y < 0)
                this.Move( MoveDirection.Down );
        };

        input.Player_1.Action.performed += ctx =>
        {
            var sel = this.eventSystem.currentSelectedGameObject;

            if ( sel != null )
            {
                var sub = sel.GetComponent<ISubmitHandler>();

                sub.OnSubmit( new BaseEventData( this.eventSystem ) );
            }
        };

        input.Enable();
    }

    public void Move( MoveDirection direction )
    {
        AxisEventData data = new AxisEventData( this.eventSystem );

        data.moveDir = direction;

        data.selectedObject = this.eventSystem.currentSelectedGameObject;

        ExecuteEvents.Execute( data.selectedObject, data, ExecuteEvents.moveHandler );
    }
}