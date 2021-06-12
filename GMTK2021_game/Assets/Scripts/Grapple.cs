using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public float grappledistance;
    public GameObject grapplingline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, Vector2.MoveTowards(transform.position, Vector2.MoveTowards(mousepos, transform.position, -500), grappledistance), LayerMask.GetMask("Obstacle"));
            if (hit)
            {
                if (hit.transform.tag == "Grabbable")
                {
                    GameObject newline = Instantiate(grapplingline);
                    newline.transform.position = transform.position;
                    newline.GetComponent<SpringJoint2D>().connectedBody = hit.transform.GetComponent<Rigidbody2D>();
                    newline.GetComponent<FixedJoint2D>().connectedBody = GetComponentInParent<Rigidbody2D>();
                    newline.GetComponent<LineFollow>().follow = hit.transform;

                    if (hit.transform.GetComponent<Grabbable>())
                    {
                        hit.transform.GetComponent<Grabbable>().Grab(newline);
                    }
                }
            }
        }
    }
}
