using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public event EventHandler OnPlayerGrabbedObject;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // Spawn a kitchen object
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            
            // Give the kitchen object to the player
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

            // Invoke the event to notify that the player has grabbed an object
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        } 
    }
}
