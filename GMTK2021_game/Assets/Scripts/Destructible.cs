using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            if (destroyedPrefab)
            {
                GameObject newthingy = Instantiate(destroyedPrefab);
                newthingy.transform.position = transform.position;
                newthingy.transform.rotation = transform.rotation;
            }
            Destroy(this.gameObject);
        }
    }
}
