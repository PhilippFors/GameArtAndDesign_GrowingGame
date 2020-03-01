using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public bool sphereTriggered = false;
    public bool cubeTriggered = false;
    public bool pyramidTriggered = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Equals("Sphere"))
        {
            sphereTriggered = true;
        }
        else if (other.gameObject.name.Equals("Cube"))
        {
            cubeTriggered = true;
        }
        else if (other.gameObject.name.Equals("Pyramid"))
        {
            pyramidTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name.Equals("Sphere"))
        {
            sphereTriggered = false;
        }
        else if (other.gameObject.name.Equals("Cube"))
        {
            cubeTriggered = false;
        }
        else if (other.gameObject.name.Equals("Pyramid"))
        {
            pyramidTriggered = false;
        }
    }
}
