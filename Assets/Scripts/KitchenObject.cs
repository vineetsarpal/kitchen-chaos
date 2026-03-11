using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    // Interface variable to keep track of the parent of this kitchen object, 
    // which can either be a clear counter or the player
    private IKitchenObjectParent kitchenObjectParent;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        // this.kitchenObjectParent is the previous clear counter. the param kitchenObjectParent is the new clear counter

        if (this.kitchenObjectParent != null)
        {
             this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Kitchen object parent already has a kitchen object!");
        }

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    } 
    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;    
    }
}
