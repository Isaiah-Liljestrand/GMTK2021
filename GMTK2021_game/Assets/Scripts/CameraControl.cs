using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject followobject;
    public float speed;
    public float zoomspeed;
    public float targetzoom;

    public float towardsmouseamount;
    public float towardsmousezoomamount;

    private Camera cam;
    private float originalz;
    private float originalzoom;
    private Vector3 follow;


    private void Start()
    {
        cam = GetComponent<Camera>();
        targetzoom = cam.orthographicSize;
        originalzoom = targetzoom;
        originalz = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        follow = new Vector3(followobject.transform.position.x, followobject.transform.position.y, originalz);
        //Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0;
        float distancetomouse = Vector3.Distance(followobject.transform.position, mousepos);
        if (towardsmouseamount > 0)
            follow += (mousepos - follow) * towardsmouseamount;
        float distance = Vector3.Distance(transform.position, follow);
        transform.position = Vector3.MoveTowards(transform.position, follow, distance * speed * Time.deltaTime);
        cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, targetzoom + (distancetomouse * towardsmousezoomamount), zoomspeed * Time.deltaTime);
    }

    public void ResetZoom()
    {
        targetzoom = originalzoom;
    }
}
