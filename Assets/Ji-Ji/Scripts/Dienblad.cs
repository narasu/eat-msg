using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dienblad
{
    private float mouseX, mouseY;
    public GameObject Hand;
    public SphereCollider SphereBounds;

    public Dienblad(SphereCollider _sphereBounds)
    {
        SphereBounds = _sphereBounds;
    }

    public void OnTick(float mouseX, float mouseY)
    {
        this.mouseX = mouseX;
        this.mouseY = mouseY;
        DienBladMovement();
        DienBladVerticalAxis();
    }
    private void DienBladMovement()
    {
        if (BodyController.Mouse0IsDown && !BodyController.Mouse1IsDown)
        {
            Vector3 tempMovement = (Camera.main.transform.right * mouseX + Camera.main.transform.forward * mouseY) * Time.deltaTime * 120;
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
            Vector3 tempMovement = temp * Time.deltaTime * 120;
            Vector3 proposedPosition = Hand.transform.position + tempMovement;

            // Clampt de voorgestelde positie binnen de bounds van de SphereCollider
            proposedPosition = ClampPositionWithinBounds(proposedPosition, SphereBounds);

            // Pas de geclampte positie toe
            Hand.transform.position = proposedPosition;

            Debug.Log("muist1 werkt");
        }
    }
}
