using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DienbladLimitController : MonoBehaviour
{
    public GameObject[] SpawnPoints, SpawnableObjects;

    void Start()
    {
        if (SpawnPoints.Length > 0)
        {
            //check of er spawnpoints aanwezig zijn, zo ja, dan spawn je random objecten uit een andere lijst
            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                var rand = UnityEngine.Random.Range(0,SpawnableObjects.Length);
                GameObject instance = Instantiate(SpawnableObjects[rand], SpawnPoints[i].transform.position, quaternion.identity);
                instance.transform.SetParent(this.gameObject.transform, true);
                // SpawnPoints[i].transform.position = SpawnableObjects[rand].transform.position;
            }
        }
    }

    void Update()
    {

    }
}
