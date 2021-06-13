using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassManager : MonoBehaviour
{
    public float strength;
    public float attachmentscaler;
    List<GameObject> attachedObjects;
    // Start is called before the first frame update
    void Start()
    {
        attachedObjects = new List<GameObject>();
    }

    public void AddObject(GameObject recruit)
    {
        Debug.Log("AddObject called");
        float objectmass = recruit.GetComponent<Rigidbody2D>().mass;
        Debug.Log(strength);
        strength += objectmass * attachmentscaler;
        Debug.Log(strength);
        attachedObjects.Add(recruit);
        UpdateStrength();
    }

    public void RemoveObject(GameObject fired)
    {

        float objectmass = fired.GetComponent<Rigidbody2D>().mass;
        if(attachedObjects.Contains(fired))
        {
            attachedObjects.Remove(fired);
        }
        UpdateStrength();
    }

    void UpdateStrength()
    {
        Debug.Log("Update Strength called");
        this.transform.parent.GetComponentInChildren<Arm>().grabstrength = strength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
