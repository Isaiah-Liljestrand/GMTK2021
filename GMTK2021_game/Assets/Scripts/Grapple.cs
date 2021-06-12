using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public float grappledistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0;

        RaycastHit2D hit = Physics2D.Linecast(transform.position, Vector2.MoveTowards(transform.position, Vector2.MoveTowards(mousepos, transform.position, -500), grappledistance), LayerMask.GetMask("Ground"));
        RaycastHit2D[] hitany = Physics2D.LinecastAll(transform.position, Vector2.MoveTowards(transform.position, Vector2.MoveTowards(mousepos, transform.position, -500), grappledistance));
        //Set grapple target
        if (hit)
        {

        }
    }
}
