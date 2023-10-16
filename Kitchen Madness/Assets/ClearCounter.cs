using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : InteractableBase
{
    //[SerializeField] KitchenObjectSO kitchenObject;
    [SerializeField] Transform top;
    GameObject currentObject;

    public override void Interact(GameObject gameObject)
    {
        base.Interact(gameObject);

        var kitchenObjectHolder = gameObject.GetComponent<IKitchenObjectHolder>();

        if (currentObject != null)
        {
            kitchenObjectHolder.AddObject(currentObject);
            currentObject = null;
        }
        else
        {
            var kitchenObject = kitchenObjectHolder.RemoveObject();

            if (kitchenObject != null)
            {

                currentObject = kitchenObject;

                kitchenObject.transform.parent = this.transform;
                kitchenObject.transform.position = top.position;
            }
        }

        //var newFood = Instantiate(kitchenObject.prefab, this.transform);
        //newFood.transform.position = top.position;

        //Debug.Log($"Interact with ClearCounter {this.name}");
    }
}
