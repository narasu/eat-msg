using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHandler : MonoBehaviour
{
    private Action<KitchenEvent> kitchenEventHandler;
    private Func<TableEvent, int> tableEventHandler;
    private Action<OrderCompletedEvent> orderCompletedEventHandler;

    private bool hasOrder;
    private int orderNumber;

    private void Awake()
    {
        kitchenEventHandler = OnKitchenEvent;
        tableEventHandler = OnTableEvent;
        orderCompletedEventHandler = OnOrderCompletedEvent;
    }

    private void OnEnable()
    {
        EventManager.Subscribe(typeof(KitchenEvent), kitchenEventHandler);
        
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(KitchenEvent), kitchenEventHandler);
        
    }

    //invoked when the player 
    private void OnKitchenEvent(KitchenEvent _event)
    {
        EventManager.Subscribe(typeof(TableEvent), tableEventHandler);
        EventManager.Subscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
        orderNumber = _event.OrderNumber;
    }

    private int OnTableEvent(TableEvent _event)
    {
        return orderNumber;
    }

    private void OnOrderCompletedEvent(OrderCompletedEvent _event)
    {
        EventManager.Unsubscribe(typeof(TableEvent), tableEventHandler);
        EventManager.Unsubscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
    }
}
