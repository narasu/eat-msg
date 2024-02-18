using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Table : MonoBehaviour
{
    private int tableNumber;
    private int triggerCount = 0;
    [SerializeField] private TMP_Text floatingNumber;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerCount == 0)
            {
                // if the player is subscribed to TableEvent, the callback returns true
                if (EventManager.InvokeCallback(new TableEvent(), out int orderNumber))
                {
                    if (orderNumber == tableNumber)
                    {
                        EventManager.Invoke(new MessageEvent("\"Thank you!\""));
                        // the correct order has arrived to this table
                        EventManager.Invoke(new OrderCompletedEvent());
                    }
                }
            }
            

            triggerCount++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerCount--;
           
        }
    }

    public void SetTableNumber(int _n)
    {
        tableNumber = _n;
        floatingNumber.text = tableNumber.ToString();
    }
}
