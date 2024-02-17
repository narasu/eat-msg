using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BodyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public float WalkSpeed, TurnSpeed, Friction;
    [SerializeField] private GameObject torsoNode, hand;
    private CharacterController characterController;

    private Vector3 velocity;
    private float walkAxis, turnAxis, strafeAxis, mouseX, mouseY;
    private float angularVelocity;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        walkAxis = Input.GetAxisRaw("Vertical");
        turnAxis = Input.GetAxisRaw("Horizontal");
        strafeAxis = Input.GetAxisRaw("Strafe");
        mouseX = Input.GetAxis("Mouse X");
        
        
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
        
        angularVelocity = Mathf.LerpAngle(angularVelocity, turnAxis * TurnSpeed * Time.deltaTime, Friction);
        transform.Rotate(Vector3.up, angularVelocity);
        torsoNode.transform.Rotate(-Vector3.right, mouseX * Time.deltaTime * 120.0f);

        Vector3 newSpeed = Vector3.Lerp(velocity, relativeForward * WalkSpeed + relativeStrafe * WalkSpeed, Friction);
        velocity = new Vector3(newSpeed.x, -9.81f, newSpeed.z);
        characterController.Move(velocity * Time.deltaTime);
    }
}
