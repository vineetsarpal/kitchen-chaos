using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public event EventHandler OnPlayerGrabbedObject;
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Player is not carrying anything

            // Spawn a kitchen object
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            // Invoke the event to notify that the player has grabbed an object
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        } 
    }
}
