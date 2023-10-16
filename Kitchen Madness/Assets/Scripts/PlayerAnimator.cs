using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    const string IS_WALKING = "IsWalking";

    [SerializeField] PlayerMovement playerMovement;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement == null)
            playerMovement = GetComponentInParent<PlayerMovement>();

        animator = GetComponent<Animator>();
        animator.SetBool(IS_WALKING, playerMovement.IsWalking);
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, playerMovement.IsWalking);
    }
}
