using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DienbladLimitController : MonoBehaviour
{
public GameObject fles; // Sleep je fles GameObject hierin via de Inspector
    public float valHoek = 30f; // De hoek waarbij de fles valt

    void Update()
    {
        // Controleer of de hoek van het dienblad de valHoek overschrijdt
        if (Quaternion.Angle(transform.rotation, Quaternion.identity) > valHoek)
        {
            // Maak de fles los van het dienblad zodat het kan vallen
            fles.transform.parent = null;
            Rigidbody flesRb = fles.GetComponent<Rigidbody>();
            if (flesRb != null)
            {
                flesRb.isKinematic = false; // Zorg ervoor dat de fles reageert op zwaartekracht
            }
        }
    }
}
