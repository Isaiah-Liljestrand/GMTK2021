using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float force;
    private Rigidbody2D rb;
    private Grabbable gb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gb = GetComponent<Grabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gb.Connected())
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 0;

            Debug.Log(Vector2.MoveTowards(Vector2.zero, mousepos - transform.position, force));
            rb.AddForce(Vector2.MoveTowards(Vector2.zero, mousepos - transform.position, force));
        }
    }
}
