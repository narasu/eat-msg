using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BackgroundMusic : MonoBehaviour
{
    public StudioEventEmitter myEventEmitter;
    [Range(0, 100)]
    public float parameterValue;
    private bool EventInstanceIsValid = false;

    // Start is called before the first frame update
    void Start()
    {
        if (myEventEmitter.EventInstance.isValid())
        {
            EventInstanceIsValid = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(BodyController.PlayerVelocity);
        if (EventInstanceIsValid)
        {
            Vector3 horizontalVelocity = BodyController.PlayerVelocity;
            horizontalVelocity.y = 0; // Negeer verticale snelheid
            float horizontalSpeed = horizontalVelocity.magnitude;

            float speed = horizontalVelocity.magnitude;

            float normalizedSpeed = (horizontalSpeed / 3) * 100f;

            parameterValue = normalizedSpeed;
            Debug.Log(normalizedSpeed);
            // Stel de waarde van een parameter in. Vervang "ParameterName" met de naam van je parameter.
            // Vervang "parameterValue" met de waarde die je wilt instellen.
            myEventEmitter.EventInstance.setParameterByName("Player_velocity", parameterValue);
        }
    }
}
