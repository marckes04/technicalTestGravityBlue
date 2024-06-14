using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerInput;
    private CharacterController characterController;
    private Animator animator;

    [SerializeField]
    private float walkSpeed = 2f;

    private Vector2 currentMovementInput;
    private Vector3 currentMovement;

    private bool isMovementPressed;

    private float rotationSpeed = 720f;

    private int speedHash;

    private void Awake()
    {
        playerInput = new PlayerController();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        speedHash = Animator.StringToHash("speed");

        playerInput.Player.Move.started += OnMovementInput;
        playerInput.Player.Move.canceled += OnMovementInput;
        playerInput.Player.Move.performed += OnMovementInput;
    }

    void HandleRotation()
    {
        if (isMovementPressed)
        {
            Vector3 positionToLookAt = new Vector3(currentMovement.x, 0.0f, currentMovement.z);
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void FixedUpdate()
    {
        HandleRotation();

        Vector3 horizontalMovement = new Vector3(currentMovement.x, 0.0f, currentMovement.z) * walkSpeed * Time.deltaTime;

        characterController.Move(horizontalMovement);

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        float speed = isMovementPressed ? 1f : 0f;
        animator.SetFloat(speedHash, speed);
    }

    void OnEnable()
    {
        playerInput.Player.Enable();
    }

    void OnDisable()
    {
        playerInput.Player.Disable();
    }
}
