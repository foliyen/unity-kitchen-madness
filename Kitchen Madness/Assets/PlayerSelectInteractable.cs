using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSelectInteractable : MonoBehaviour
{
    [SerializeField] LayerMask countersLayerMask;
    [SerializeField] float interactDistance = 2f;

    PlayerControllerInput controllerInput;
    Vector3 lastInteractDir = Vector3.zero;

    IInteractable selectedInteractable;
    

    private void Awake()
    {
        controllerInput = GetComponent<PlayerControllerInput>();
    }

    void Start()
    {
        controllerInput.OnInteractAction += ControllerInput_OnInteractAction;
    }

    private void ControllerInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (selectedInteractable != null)
        {
            selectedInteractable.Interact(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = controllerInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out IInteractable interactable))
            {
                // is clear counter
                selectedInteractable?.Deselect();
                selectedInteractable = interactable;
                selectedInteractable.Select();
            }
            else
            {
                selectedInteractable?.Deselect();
                selectedInteractable = null;                
            }
        }
        else
        {
            selectedInteractable?.Deselect();
            selectedInteractable = null;            
        }
    }
}
