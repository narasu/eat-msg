using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class BodyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private CharacterController characterController;
    private Vector3 lastMousePosition;
    private Vector3 mouseDelta;

    private Transform camTransform;

    private float hMovementSpeed;
    public float WalkSpeed, TurnSpeed, Friction;
    private Vector3 velocity;
    private BodyControls bodyControls;
    private float walkAxis, turnAxis, strafeAxis;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        camTransform = Camera.main.transform;
        bodyControls = new BodyControls();
    }

    private void Update()
    {
        walkAxis = bodyControls.BodyMovement.Walk.ReadValue<float>();
        turnAxis = bodyControls.BodyMovement.Turn.ReadValue<float>();
        strafeAxis = bodyControls.BodyMovement.Strafe.ReadValue<float>();
        Debug.Log(walkAxis);
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        Vector3 relativeForward = transform.forward * walkAxis;
        Vector3 relativeStrafe = transform.right * strafeAxis;
        
        /*if (inputVector.sqrMagnitude > .0f)
        {
            float angle = Mathf.Atan2(relativeForward.x, relativeForward.z) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, .2f);
            //animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }*/
        
        
        transform.Rotate(Vector3.up, turnAxis * TurnSpeed * Time.deltaTime);

        Vector3 newSpeed = Vector3.Lerp(velocity, relativeForward * WalkSpeed + relativeStrafe * WalkSpeed, Friction);
        velocity = new Vector3(newSpeed.x, -9.81f, newSpeed.z);
        characterController.Move(velocity * Time.deltaTime);
    }
}
