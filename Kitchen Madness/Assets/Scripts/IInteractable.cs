using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject gameObject);
    void Select();
    void Deselect();
}
