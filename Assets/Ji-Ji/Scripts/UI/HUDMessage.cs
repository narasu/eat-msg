using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

[RequireComponent(typeof(TMP_Text))]
public class HUDMessage : MonoBehaviour
{
    private TMP_Text tmpComponent;

    private Action<MessageEvent> messageEventHandler;

    private Queue<string> messageQueue = new();
    public float timerLength;
    private float currentTime;
    private bool running;

    private void Awake()
    {
        messageEventHandler = OnMessage;
        tmpComponent = GetComponent<TMP_Text>();
        tmpComponent.text = "";
    }

    private void Update()
    {
        if (running)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timerLength)
            {
                currentTime = .0f;
                if (messageQueue.TryDequeue(out string message))
                {
                    tmpComponent.text = message;
                    
                }
                else
                {
                    tmpComponent.text = "";
                    running = false;
                }
            }
        }
    }

    private void OnEnable()
    {
        
        EventManager.Subscribe(typeof(MessageEvent), messageEventHandler);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(MessageEvent), messageEventHandler);
    }

    private void OnMessage(MessageEvent _event)
    {
        messageQueue.Enqueue(_event.Message);
        if (tmpComponent.text == "")
        {
            tmpComponent.text = messageQueue.Dequeue();
        }

        running = true;
    }
}