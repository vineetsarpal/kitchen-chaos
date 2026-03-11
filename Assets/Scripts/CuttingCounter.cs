using Unity.VisualScripting;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no kitchen object here
            if (player.HasKitchenObject())
            {
                // Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else
            {
                // Player is not carrying anything
            }
        } else   
        {
            // There is a kitchen object here
            if (player.HasKitchenObject())
            {
                // Player is carrying something

            } else
            {
                // Player is not carring anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            // There is a kitchen object here
            GetKitchenObject().DestroySelf();

            // Spawn a cut kitchen object
            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }
}
