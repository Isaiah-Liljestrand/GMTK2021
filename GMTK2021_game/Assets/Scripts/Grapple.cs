using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public float grappledistance;
    public GameObject grapplingline;
    public float timedestroygrapple;
    public GameObject pullline;
    public float timedestroypull;
    public GameObject grapplesound;
    public GameObject target;

    private List<GameObject> grappledobjects;

    // Start is called before the first frame update
    void Start()
    {
        target.transform.parent = null;
        grappledobjects = new List<GameObject>();
    }

    public void RemoveObject(GameObject obj)
    {
        if (grappledobjects.Contains(obj))
        {
            grappledobjects.Remove(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0;

        RaycastHit2D hit = Physics2D.Linecast(transform.position, Vector2.MoveTowards(transform.position, Vector2.MoveTowards(mousepos, transform.position, -500), grappledistance), LayerMask.GetMask("Obstacle"));
        if (hit)
        {
            if (hit.transform.tag == "Grabbable")
            {
                target.SetActive(true);
                target.transform.position = hit.point;

                if (Input.GetMouseButtonDown(0))
                {
                    if (!grappledobjects.Contains(hit.transform.gameObject))
                    {
                        GameObject newline = null;
                        if (hit.transform.GetComponent<Grabbable>())
                        {
                            newline = Instantiate(grapplingline);
                            hit.transform.GetComponent<Grabbable>().Grab(newline);
                            Destroy(newline, timedestroygrapple);
                        }
                        else
                        {
                            if (hit.transform.GetComponent<Rigidbody2D>())
                            {
                                newline = Instantiate(pullline);
                                Destroy(newline, timedestroypull);
                            }
                        }

                        if (hit.transform.GetComponent<Rigidbody2D>())
                        {
                            if (newline)
                            {
                                Destroy(Instantiate(grapplesound), timedestroypull);
                                newline.transform.position = new Vector3(transform.position.x, transform.position.y, 10);
                                newline.GetComponent<SpringJoint2D>().connectedBody = hit.transform.GetComponent<Rigidbody2D>();
                                newline.GetComponent<FixedJoint2D>().connectedBody = GetComponentInParent<Rigidbody2D>();
                                newline.GetComponent<LineFollow>().follow = hit.transform;
                                newline.GetComponent<GrappleLineScript>().grapple = this;
                                newline.GetComponent<GrappleLineScript>().objectholding = hit.transform.gameObject;
                                grappledobjects.Add(hit.transform.gameObject);
                            }
                        }
                    }
                }
            }
            else
            {
                target.SetActive(false);
            }
        }
        else
        {
            target.SetActive(false);
        }
    }
}
