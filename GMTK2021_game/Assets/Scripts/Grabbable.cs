using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public int requiredTouchCount = 2;
    private int touchCount = 0;

    public void Touch()
    {
        touchCount++;
        if (touchCount >= requiredTouchCount)
            this.tag = "Player";
    }

    public void Grab()
    {
        foreach(Connector c in GetComponentsInChildren<Connector>())
        {
            c.GetComponent<Collider2D>().enabled = true;
        }
    }
}
