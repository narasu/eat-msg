using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Kitchen : MonoBehaviour
{
    private int numberOfTables;
    private bool isReady = true;
    private bool playerIsWaiting;
    private int triggerCount;
    private int tableNumber;
    private Action<OrderCompletedEvent> orderCompletedEventHandler;

    private void OnEnable()
    {
        
        // lookup all tables and assign a number to each
        // TODO: move to separate class
        var tables = FindObjectsOfType<Table>();
        for (int i = 0; i < tables.Length; i++)
        {
            tables[i].SetTableNumber(i+1);
        }
        numberOfTables = tables.Length;
        // Debug.Log(numberOfTables);
        // end table lookup
        
        // subscribe to OrderCompletedEvent so that when the player completes an order, the kitchen is ready with a new one
        orderCompletedEventHandler = OnOrderCompleted;
        EventManager.Subscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
    }
    
    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
    }

    private void OnTriggerEnter(Collider other)
    {
        // register the number of player trigger enters
        // to prevent things going wrong if more than one object tagged "Player" enters the trigger
        if (other.CompareTag("Player"))
        {
            triggerCount++;
            playerIsWaiting = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // if an order is ready and the player is in the trigger, pass the order
        if (other.CompareTag("Player") && playerIsWaiting && isReady)
        {
            RandomizeTable();
            EventManager.Invoke(new KitchenEvent(tableNumber));
            Debug.Log($"Chef: \"Table number {tableNumber}!\"");
            isReady = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerCount--;
            if (triggerCount == 0)
            {
                playerIsWaiting = false;
            }
        }
    }

    private void OnOrderCompleted(OrderCompletedEvent _event)
    {
        isReady = true;
        Debug.Log("Chef: \"Got a new order ready!\"");
    }
    
    //adding 1 to the random result because tables begin counting at 1 (and random.range is maxExclusive)
    private void RandomizeTable()
    {
        int lastTable = tableNumber;
        while (tableNumber == lastTable)
        {
            tableNumber = Random.Range(0, numberOfTables) + 1;
        }
    }
}
