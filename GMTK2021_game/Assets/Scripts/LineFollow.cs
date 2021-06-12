using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFollow : MonoBehaviour
{
    public Transform follow;
    private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, follow.position);
        }
    }
}
