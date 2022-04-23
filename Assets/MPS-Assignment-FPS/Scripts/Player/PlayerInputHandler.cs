using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerInputHandler : MonoBehaviour
{
    #region Variables
    
    [Header("Settings")]
    [SerializeField] private float walkingSpeed = 7.5f;
    [SerializeField] private float runningSpeed = 11.5f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 45.0f;
    
    [Header("References")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private CharacterController characterController;
    
    // Private
    private Vector3 _moveDirection = Vector3.zero;
    private float _rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    #endregion

    #region Unity Methods

    private void Start()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        var forward = transform.TransformDirection(Vector3.forward);
        var right = transform.TransformDirection(Vector3.right);
        
        // Press Left Shift to run
        var isRunning = Input.GetKey(KeyCode.LeftShift);
        var curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        var curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        var movementDirectionY = _moveDirection.y;
        _moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            _moveDirection.y = jumpSpeed;
        }
        else
        {
            _moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            _moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(_moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        
        // Shooting
        if (Input.GetMouseButtonDown(0))
            TryShoot();
    }

    #endregion

    #region Methods

    private void TryShoot()
    {
        Debug.Log("Shoot?");
        
    }

    #endregion
}