using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAngle : MonoBehaviour
{
    public float valHoek = 30f; // De hoek waarbij de fles valt
    private Rigidbody flesRb;

    // Start is called before the first frame update
    void Start()
    {
        flesRb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Controleer of de hoek van het dienblad de valHoek overschrijdt
        if (Quaternion.Angle(transform.rotation, Quaternion.identity) > valHoek)
        {
            // Maak de fles los van het dienblad zodat het kan vallen
            this.gameObject.transform.parent = null;
            
            if (flesRb != null)
            {
                flesRb.isKinematic = false; // Zorg ervoor dat de fles reageert op zwaartekracht
            }
        }
    }
}
