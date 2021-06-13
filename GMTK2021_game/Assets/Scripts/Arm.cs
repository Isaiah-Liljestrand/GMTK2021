using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public float grabdistance;
    public float grabstrength;
    public HingeJoint2D hinge;
    public JointMotor2D motor;
    public bool armon;


    // Start is called before the first frame update
    void Start()
    {
        hinge = this.GetComponentInParent<HingeJoint2D>();
        motor = hinge.motor;
        armon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (armon == true)
        {
            JointMotor2D m = hinge.motor;
            m.motorSpeed = 500;
            if (Input.GetMouseButton(1))
            {
                Vector2 mousepos = Input.mousePosition;
                Vector2 objectpos = hinge.connectedBody.position;
                Vector2 shippos = this.GetComponentInParent<Rigidbody2D>().position;

                float mouseangle = Vector2.Angle(shippos, mousepos);

                float objectangle = Vector2.Angle(shippos, objectpos);

                float dif = mouseangle - objectangle;

                if (dif > 10)
                {
                    motor.motorSpeed = 500;
                }

                if (dif < -10)
                {
                    motor.motorSpeed = -500;
                }
            }
            else
            {
                //Simply turn off hinge and arm component
                armon = false;
                hinge.enabled = false;
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
                    //motor.motorSpeed = 0;
                }
            }
        }
    }
}