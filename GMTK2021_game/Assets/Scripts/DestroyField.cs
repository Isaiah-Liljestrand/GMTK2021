using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyField : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Destructible>())
        {
            collision.GetComponent<Destructible>().Destructo();
        }
    }
}
