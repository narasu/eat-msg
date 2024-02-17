using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private int tableNumber;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // if the player is subscribed to TableEvent, the callback returns true
            if (EventManager.InvokeCallback(new TableEvent(), out int orderNumber))
            {
                if (orderNumber == tableNumber)
                {
                    // the correct order has arrived to this table
                    EventManager.Invoke(new OrderCompletedEvent());
                }
            }
        }
    }
}
