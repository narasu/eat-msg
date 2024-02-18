using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreCounter : MonoBehaviour
{
    private const string PREFIX = "Score: ";
    private int score;
    private TMP_Text tmpComponent;

    private Action<OrderCompletedEvent> orderCompletedEventHandler;
    
    private void Awake()
    {
        orderCompletedEventHandler = AddScore;
        tmpComponent = GetComponent<TMP_Text>();
        tmpComponent.text = PREFIX + "0";
    }
    
    private void OnEnable()
    {
        
        EventManager.Subscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(OrderCompletedEvent), orderCompletedEventHandler);
    }

    private void AddScore(OrderCompletedEvent _event)
    {
        score++;
        tmpComponent.text = PREFIX + score;
    }
}
