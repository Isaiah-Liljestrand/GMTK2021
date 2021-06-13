using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleLineScript : MonoBehaviour
{
    public Grapple grapple;
    public GameObject objectholding;

    private void OnDestroy()
    {
        grapple.RemoveObject(objectholding);
    }
}
