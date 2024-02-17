using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Kitchen : MonoBehaviour
{
    private bool isReady, playerIsWaiting;
    private int tableNumber;
    [SerializeField] [Range(1, 32)] private int numberOfTables;

    private void OnTriggerEnter(Collider other)
    {
        // register if the player is currently in the trigger
        if (other.CompareTag("Player"))
        {
            playerIsWaiting = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // if an order is ready and the player is in the trigger, pass the order
        if (other.CompareTag("Player") && playerIsWaiting)
        {
            RandomizeTable();
            EventManager.Invoke(new KitchenEvent(tableNumber));
            isReady = false;
            playerIsWaiting = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsWaiting = false;
        }
    }

    private void RandomizeTable() => tableNumber = Random.Range(0, numberOfTables) + 1;
}
