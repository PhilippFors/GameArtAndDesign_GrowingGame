using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidTrigger : MonoBehaviour
{
    public bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Equals("Pyramid"))
        {
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        triggered = false;
    }
}
