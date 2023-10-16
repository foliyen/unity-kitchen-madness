using UnityEngine;

public class ContainerCounter: MonoBehaviour, IInteractable
{
    [SerializeField] KitchenObjectSO kitchenObject;
    [SerializeField] GameObject selectedVisual;

    public void Deselect()
    {
        selectedVisual.SetActive(false); 
    }

    public void Interact(GameObject gameObject)
    {

        IKitchenObjectHolder holder = gameObject.GetComponent<IKitchenObjectHolder>();

        if (holder != null)
        {
            var newObject = Instantiate(kitchenObject.prefab, gameObject.transform);

            holder.AddObject(newObject.gameObject);
        }        
    }

    public void Select()
    {
        selectedVisual.SetActive(true);        
    }
}
