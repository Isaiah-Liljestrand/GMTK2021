using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float playertime;
    public bool started;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        playertime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            playertime += Time.deltaTime;
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                started = true;
            }
            if(Input.GetMouseButtonDown(1))
            {
                started = true;
            }
        }
    }
}
