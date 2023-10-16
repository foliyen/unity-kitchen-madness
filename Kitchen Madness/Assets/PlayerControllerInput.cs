using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternativeAction;

    PlayerInputActions playerInputActions;

    // Start is called before the first frame update
    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += (x => { OnInteractAction?.Invoke(this, EventArgs.Empty); });
        playerInputActions.Player.IntercatAlternative.performed += (x => { OnInteractAlternativeAction?.Invoke(this, EventArgs.Empty); });
    }

    private void OnDestroy()
    {
        playerInputActions.Player.Disable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }
}
