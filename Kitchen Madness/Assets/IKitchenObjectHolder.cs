using UnityEngine;

public interface IKitchenObjectHolder
{
    bool IsHolding();

    GameObject RemoveObject();
    void AddObject(GameObject kitchenObject);

}
