using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HealthCounter : MonoBehaviour
{
    private const string PREFIX = "Lives: ";
    public int lives = 3;
    private TMP_Text tmpComponent;

    private Action<OrderFailedEvent> orderFailedEventHandler;
    
    private void Awake()
    {
        orderFailedEventHandler = SubtractHealth;
        tmpComponent = GetComponent<TMP_Text>();
        tmpComponent.text = PREFIX + "0";
    }
    
    private void OnEnable()
    {
        
        EventManager.Subscribe(typeof(OrderFailedEvent), orderFailedEventHandler);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(OrderFailedEvent), orderFailedEventHandler);
    }

    private void SubtractHealth(OrderFailedEvent _event)
    {
        lives--;
        tmpComponent.text = PREFIX + lives;
        if (lives <= 0)
        {
            EventManager.Invoke(new LoseEvent());
        }
    }
}
