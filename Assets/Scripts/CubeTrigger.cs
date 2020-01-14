using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    public bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Equals("Cube"))
        {
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        triggered = false;
    }
}
