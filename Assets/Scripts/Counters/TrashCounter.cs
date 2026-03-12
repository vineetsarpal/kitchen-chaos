using UnityEngine;

public class TrashCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            // Player is carrying something
            player.GetKitchenObject().DestroySelf();
        }
    }
}
