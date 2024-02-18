using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BodyController : MonoBehaviour
{
    //sphere collider
    // [SerializeField]
    // public SphereCollider MovementBounds;
    // public Dienblad dienBladScript;

    //delegates
    //public Action<float, float> eventTick;
    [SerializeField] private Animator animator;
    public float WalkSpeed, TurnSpeed, Friction;
    [SerializeField] private GameObject torsoNode, hand;
    private CharacterController characterController;
    public static bool Mouse0IsDown, Mouse1IsDown;
    private Vector3 velocity;
    private float walkAxis, turnAxis, strafeAxis, mouseX, mouseY;
    private float angularVelocity;

    private void Awake()
    {
        //dienBladScript = new Dienblad(MovementBounds);

        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        /*if (hand != null)
        {
            dienBladScript.Hand = hand;
        }
        eventTick += dienBladScript.OnTick;*/
    }
    private void OnDestroy()
    {
        //eventTick = null;
    }

    private void Update()
    {
        walkAxis = Input.GetAxisRaw("Vertical");
        turnAxis = Input.GetAxisRaw("Horizontal");
        strafeAxis = Input.GetAxisRaw("Strafe");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        Mouse0IsDown = Input.GetKey(KeyCode.Mouse0);
        Mouse1IsDown = Input.GetKey(KeyCode.Mouse1);

        Vector3 relativeForward = transform.forward * walkAxis;
        Vector3 relativeStrafe = transform.right * strafeAxis;

        angularVelocity = Mathf.LerpAngle(angularVelocity, turnAxis * TurnSpeed * Time.deltaTime, Friction);
        transform.Rotate(Vector3.up, angularVelocity);

        //body mouse movement
        if (!Mouse0IsDown && !Mouse1IsDown) 
        {
            torsoNode.transform.Rotate(-Vector3.right, mouseX * Time.deltaTime * 120.0f);
        }

        Vector3 newSpeed = Vector3.Lerp(velocity, relativeForward * WalkSpeed + relativeStrafe * WalkSpeed, Friction);
        velocity = new Vector3(newSpeed.x, -9.81f, newSpeed.z);
        characterController.Move(velocity * Time.deltaTime);
        
    }

    private void FixedUpdate()
    {
        // eventTick?.Invoke(mouseX, mouseY);
    }
}

