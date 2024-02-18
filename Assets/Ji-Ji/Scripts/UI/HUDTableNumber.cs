using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HUDTableNumber : MonoBehaviour
{
    private TMP_Text tmpComponent;
    private Action<KitchenEvent> kitchenEventHandler;
    private Action<OrderCompletedEvent> orderCompletedEventHandler;

    private void Awake()
    {
        tmpComponent = GetComponent<TMP_Text>();
        tmpComponent.text = "";
    }

    private void OnEnable()
    {
        kitchenEventHandler = SetOrderNumber;
        orderCompletedEventHandler = ClearText;
        EventManager.Subscribe(typeof(KitchenEvent), kitchenEventHandler);
        EventManager.Subscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(KitchenEvent), kitchenEventHandler);
        EventManager.Unsubscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
    }

    private void SetOrderNumber(KitchenEvent _event)
    {
        tmpComponent.text = $"Current order: {_event.OrderNumber}";
    }

    private void ClearText(OrderCompletedEvent _event)
    {
        tmpComponent.text = "";
    }
}
