using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<Rigidbody2D>())
            {
                HingeJoint2D newhinge = transform.parent.gameObject.AddComponent<HingeJoint2D>();
                newhinge.connectedBody = collision.GetComponent<Rigidbody2D>();
                newhinge.anchor = transform.localPosition;
                newhinge.enableCollision = true;
                GetComponentInParent<Grabbable>().Touch();
                this.enabled = false;
            }
        }
    }
}
