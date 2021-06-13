using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public float grabdistance;
    public float grabstrength;
    public HingeJoint2D hinge;
    public bool armon;
    public LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        hinge = GetComponentInParent<HingeJoint2D>();
        armon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (armon)
        {
            JointMotor2D m = hinge.motor;

            if (Input.GetMouseButton(1))
            {
                if (!hinge.connectedBody)
                {
                    armon = false;
                    hinge.enabled = false;
                    lr.enabled = false;
                    return;
                }
                Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 objectpos = hinge.connectedBody.position;
                Vector2 shippos = this.transform.position;

                Vector2 shiptomouse = shippos - mousepos;

                Vector2 shiptoobject = shippos - objectpos;

               

                float dif = Vector2.SignedAngle(shiptomouse, shiptoobject);

                //Vector2 shippos = GetComponentInParent<Rigidbody2D>().position;

                lr.enabled = true;
                lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 10));
                lr.SetPosition(1, new Vector3(objectpos.x, objectpos.y, 10));

                m.motorSpeed = (Mathf.Clamp(dif, -90, 90)/90) * -grabstrength;
                /*if (dif > 10)
                {
                    m.motorSpeed = -grabstrength;
                }

                if (dif < -10)
                {
                    m.motorSpeed = grabstrength;
                }
                if (dif > -10 && dif < 10)
                {
                    m.motorSpeed = 0;
                }*/
                hinge.motor = m;
            }
            else
            {
                //Simply turn off hinge and arm component
                armon = false;
                hinge.enabled = false;
                lr.enabled = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Linecast(transform.position, Vector2.MoveTowards(transform.position, Vector2.MoveTowards(mouseposition, transform.position, -500), grabdistance), LayerMask.GetMask("Obstacle"));
                if (hit && hit.transform.tag == "Grabbable")
                {
                    //Add arm stuff
                    hinge.connectedBody = hit.transform.GetComponent<Rigidbody2D>();
                    armon = true;
                    hinge.enabled = true;
                    JointMotor2D m = hinge.motor;
                    m.motorSpeed = 0;
                    hinge.motor = m;
                }
            }
        }
    }
}