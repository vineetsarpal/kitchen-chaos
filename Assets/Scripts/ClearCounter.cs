using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            kitchenObject.SetKitchenObjectParent(secondClearCounter);
        }
    }
    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            // Spawn a kitchen object
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            
            // Set the kitchen object's clear counter to this clear counter
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        } else
        {
            // Give the kitchen object to the player
            kitchenObject.SetKitchenObjectParent(player);
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
