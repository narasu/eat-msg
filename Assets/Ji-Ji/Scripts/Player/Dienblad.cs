using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dienblad : MonoBehaviour
{
    private float mouseX, mouseY, moveSpeed = 20;
    public GameObject Hand;
    public SphereCollider SphereBounds;
    private Rigidbody rb;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private bool isFallen;

    private Action<KitchenEvent> kitchenEventHandler;
    private Action<OrderCompletedEvent> orderCompletedEventHandler;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
        kitchenEventHandler = ResetDienblad;
        orderCompletedEventHandler = _ => gameObject.SetActive(false);
        EventManager.Subscribe(typeof(KitchenEvent), kitchenEventHandler);
        EventManager.Subscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        
        DienBladMovement();
        DienBladVerticalAxis();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Player") && !isFallen)
        {
            transform.SetParent(null);
            rb.constraints = RigidbodyConstraints.None;
            EventManager.Invoke(new MessageEvent("OOPS"));
            EventManager.Invoke(new OrderFailedEvent());
            isFallen = true;
        }
    }


    private void OnDestroy()
    {
        EventManager.Unsubscribe(typeof(KitchenEvent), kitchenEventHandler);
        EventManager.Unsubscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
    }

    private void DienBladMovement()
    {
        if (BodyController.Mouse0IsDown && !BodyController.Mouse1IsDown)
        {
            Vector3 tempMovement = (Camera.main.transform.right * mouseX + Camera.main.transform.forward * mouseY) * (Time.deltaTime * moveSpeed);
            Vector3 proposedPosition = Hand.transform.position + tempMovement;

            // Clampt de voorgestelde positie binnen de bounds van de SphereCollider
            proposedPosition = ClampPositionWithinBounds(proposedPosition, SphereBounds);

            // Pas de geclampte positie toe
            Hand.transform.position = proposedPosition;
        }
    }

    private Vector3 ClampPositionWithinBounds(Vector3 proposedPosition, SphereCollider bounds)
    {
        // Verkrijg de wereldruimte bounds van de SphereCollider
        Bounds b = bounds.bounds;

        // Clampt de X, Y, en Z positie binnen de bounds
        float clampedX = Mathf.Clamp(proposedPosition.x, b.min.x, b.max.x);
        float clampedY = Mathf.Clamp(proposedPosition.y, b.min.y, b.max.y);
        float clampedZ = Mathf.Clamp(proposedPosition.z, b.min.z, b.max.z);

        return new Vector3(clampedX, clampedY, clampedZ);
    }
    private void DienBladVerticalAxis()
    {
        if (!BodyController.Mouse0IsDown && BodyController.Mouse1IsDown)
        {
            Vector3 temp = Hand.transform.forward * -mouseY;
            Vector3 tempMovement = temp * (Time.deltaTime * moveSpeed);
            Vector3 proposedPosition = Hand.transform.position + tempMovement;

            // Clampt de voorgestelde positie binnen de bounds van de SphereCollider
            proposedPosition = ClampPositionWithinBounds(proposedPosition, SphereBounds);

            // Pas de geclampte positie toe
            Hand.transform.position = proposedPosition;
        }
    }

    private void ResetDienblad(KitchenEvent _event)
    {
        gameObject.SetActive(true);
        transform.SetParent(Hand.transform);
        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isFallen = false;
    }

}
