using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Action<LoseEvent> loseEventHandler;

    private void Awake()
    {
        loseEventHandler = OnLose;
    }

    

    private void OnEnable()
    {
        EventManager.Subscribe(typeof(LoseEvent), loseEventHandler);
    }
    
    private void OnDisable()
    {
        EventManager.Unsubscribe(typeof(LoseEvent), loseEventHandler);
    }

    private void OnLose(LoseEvent _event)
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }

}
