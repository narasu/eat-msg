using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Kitchen : MonoBehaviour
{
    public Table[] tables;
    private int numberOfTables;
    private bool isReady = true;
    private bool playerIsWaiting;
    private int triggerCount;
    private int tableNumber;
    private Action<OrderCompletedEvent> orderCompletedEventHandler;
    private Action<OrderFailedEvent> orderFailedEventHandler;

    private void OnEnable()
    {
        
        // lookup all tables and assign a number to each
        // TODO: move to separate class
        for (int i = 0; i < tables.Length; i++)
        {
            tables[i].SetTableNumber(i+1);
        }
        numberOfTables = tables.Length;
        // Debug.Log(numberOfTables);
        // end table lookup
        
        // subscribe to OrderCompletedEvent so that when the player completes an order, the kitchen is ready with a new one
        orderCompletedEventHandler = OnOrderCompleted;
        orderFailedEventHandler = OnOrderFailed;
        EventManager.Subscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
        EventManager.Subscribe(typeof(OrderFailedEvent), orderFailedEventHandler);
        
        EventManager.Invoke(new MessageEvent($"Chef: \"First order is ready, come and get it!\""));
    }
    
    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
        EventManager.Unsubscribe(typeof(OrderFailedEvent), orderFailedEventHandler);
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
            EventManager.Invoke(new MessageEvent($"Chef: \"Table number {tableNumber}!\""));
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

    private void OnOrderCompleted(OrderCompletedEvent _event) => CallNewOrder();

    private void OnOrderFailed(OrderFailedEvent _event) => CallNewOrder();

    private void CallNewOrder()
    {
        if (!isReady)
        {
            isReady = true;
            EventManager.Invoke(new MessageEvent("Chef: \"Got a new order ready!\""));
        }
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
