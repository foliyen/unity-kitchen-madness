using UnityEngine;

public class InteractableBase : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject visualSelected;

    public virtual void Interact(GameObject gameObject)
    {
        Debug.Log($"Interact with ClearCounter {this.name}");
    }

    public void Deselect()
    {
        //throw new System.NotImplementedException();
        visualSelected?.SetActive(false);
    }

    public void Select()
    {
        visualSelected?.SetActive(true);
    }
}