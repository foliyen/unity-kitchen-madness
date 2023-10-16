using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectHolder
{
    GameObject kitchenObject;

    [SerializeField] Transform top;

    public void AddObject(GameObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        this.kitchenObject.transform.parent = this.transform;
        this.kitchenObject.transform.position = top.position;
    }

    public bool IsHolding()
    {
        return kitchenObject != null;
    }

    public GameObject RemoveObject()
    {
        var result = kitchenObject;

        kitchenObject = null;

        return result;
    }
}
