
// every obj in the game that the player can interact with will be tagged with this interface
public interface IInteractable
{
    //Called when a player interacts with an IInteractable. The player interacting with it is passed as a parameter.
    bool Interact(Player player);
}

// every obj in the game that is able to be hit by a snowball will be tagged with this interface
public interface IDamageable
{
    void TakeDamage(int amount);
}

public interface IPlaceableByPlayer
{
    void DefinePlayer(Player player);
}