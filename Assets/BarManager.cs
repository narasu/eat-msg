using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int FloorLevel;
    public GameObject Bar;
    public float smooth = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKey)
        {
            FloorLevel++;
        }

        if(FloorLevel == 1)
        {
            Bar.transform.position = new Vector3(0f, -0.132f, 0f);
         //   transform.rotation = Quaternion.Slerp(transform.rotation, Bar.transform.rotation, Time.deltaTime * smooth);
        }

        if(FloorLevel == 2)
        {
            Bar.transform.position = new Vector3(0f, -0.1224f, 0f);
        }

        if (FloorLevel == 3)
        {
            Bar.transform.position = new Vector3(0f, -0.1018f, 0f);
        }
        if (FloorLevel == 4)
        {
            Bar.transform.position = new Vector3(0f, -0.1114f, 0f);
        }


    }
}
