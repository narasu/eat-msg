using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Action<OrderFailedEvent> orderFailedEventHandler;


    private void Awake()
    {
        orderFailedEventHandler = OnLose;
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
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }

}
