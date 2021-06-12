using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public int requiredTouchCount = 2;
    private int touchCount = 0;
    private GameObject grappleline;

    public void Touch()
    {
        touchCount++;
        if (touchCount >= requiredTouchCount)
        {
            this.tag = "Player";
            gameObject.layer = LayerMask.NameToLayer("Default");
            if (grappleline)
                Destroy(grappleline);
        }
    }

    public void Grab(GameObject grappleline)
    {
        this.grappleline = grappleline;
        foreach(Connector c in GetComponentsInChildren<Connector>())
        {
            c.GetComponent<Collider2D>().enabled = true;
        }
    }
}
