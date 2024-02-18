using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BackgroundMusic : MonoBehaviour
{
    public StudioEventEmitter myEventEmitter;
    [Range(0,100)]
    public float parameterValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myEventEmitter.EventInstance.isValid())
        {
            // Stel de waarde van een parameter in. Vervang "ParameterName" met de naam van je parameter.
            // Vervang "parameterValue" met de waarde die je wilt instellen.
            myEventEmitter.EventInstance.setParameterByName("Player_velocity", parameterValue);
        }
    }
}
