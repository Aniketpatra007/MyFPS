using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputAction move;
    [SerializeField] private InputAction look;
    [SerializeField] private InputAction jump;
    [SerializeField] private InputAction crouch;
    [SerializeField] private InputAction sprint; 

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1.5f;

    [Header("Look Settings")]
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerCamera;

    [Header("Crouch Settings")]
    [SerializeField] private float crouchHeight = 1f;
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float crouchSpeed = 2.5f;

    private CharacterController controller;
    private Vector3 velocity;
    private float rotationX = 0f;
    private bool isCrouching = false;

    private void OnEnable()
    {
        move.Enable();
        look.Enable();
        jump.Enable();
        crouch.Enable();
        sprint.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
        jump.Disable();
        crouch.Disable();
        sprint.Disable();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessMove();
        ProcessLook();
        ProcessJump();
        ProcessCrouch();
    }

    private void ProcessMove()
    {
        Vector2 input = move.ReadValue<Vector2>();
        Vector3 direction = transform.right * input.x + transform.forward * input.y;

        float currentSpeed = speed;
        if (isCrouching)
            currentSpeed = crouchSpeed;
        else if (sprint.ReadValue<float>() > 0)
            currentSpeed = sprintSpeed;

        controller.Move(direction * currentSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void ProcessLook()
    {
        Vector2 input = look.ReadValue<Vector2>();
        float mouseX = input.x * mouseSensitivity * Time.deltaTime;
        float mouseY = input.y * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    private void ProcessJump()
    {
        if (jump.triggered && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void ProcessCrouch()
    {
        if (crouch.triggered)
        {
            isCrouching = !isCrouching;

            if (isCrouching)
            {
                gameObject.transform.localScale = new Vector3(1, crouchHeight / standingHeight, 1);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
