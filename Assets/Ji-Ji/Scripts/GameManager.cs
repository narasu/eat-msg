using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Action<OrderFailedEvent> orderFailedEventHandler;
    private float timer = 2.0f;
    private float currentTime = .0f;
    private bool timerRunning = false;

    private void Awake()
    {
        orderFailedEventHandler = OnLose;
    }

    private void Update()
    {
        if (timerRunning)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timer)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(2);
                timerRunning = false;
            }
        }
    }

    private void OnEnable()
    {
        EventManager.Subscribe(typeof(OrderFailedEvent), orderFailedEventHandler);
    }
    
    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(OrderFailedEvent), orderFailedEventHandler);
    }

    private void OnLose(OrderFailedEvent _event)
    {
        timerRunning = true;
    }

}
