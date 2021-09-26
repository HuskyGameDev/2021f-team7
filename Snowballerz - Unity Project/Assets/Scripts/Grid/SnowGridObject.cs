using UnityEngine;

public class SnowGridObject : GridObject
{
    [ Tooltip( "The amount of snow that this tile is worth, when collected by a player." ) ]
    [ SerializeField ]
    private int snowAmount = 3;

    public override void Interact (Player player)
    {
        player.SnowCount += snowAmount;

        Destroy(gameObject);
    }
}
