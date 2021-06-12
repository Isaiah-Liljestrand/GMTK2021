using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float force;
    public float animationspeed;
    private Rigidbody2D rb;
    private Grabbable gb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gb = GetComponent<Grabbable>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gb.Connected())
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 0;

            anim.speed = Mathf.Clamp(Vector2.Distance(mousepos, transform.position), 0, force) * animationspeed;
            rb.AddForce(Vector2.MoveTowards(Vector2.zero, mousepos - transform.position, force));
        }
        else
            anim.speed = 0;
    }
}
