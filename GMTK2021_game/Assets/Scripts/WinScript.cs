using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public RestartGame restart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            restart.Victory();
    }
}
