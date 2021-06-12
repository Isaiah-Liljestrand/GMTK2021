using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float multiplier;
    public Rigidbody2D rb;
    private Vector3 offset;
    private Vector3 camerastart;

    // Start is called before the first frame update
    void Start()
    {
        camerastart = Camera.main.transform.position;
        offset = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 camerachange = Camera.main.transform.position - camerastart - offset;
        if (rb)
            rb.MovePosition(new Vector3((camerachange * multiplier).x, 0, 0) + offset);
        else
            transform.position = new Vector3((camerachange * multiplier).x, 0, 0) + offset;
    }
}
