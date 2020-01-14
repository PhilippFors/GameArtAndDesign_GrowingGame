using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLookInteractionObject : MonoBehaviour, ILookAtHandler
{
    public void OnLookatEnter()
    {
        Debug.Log("OnLookatEnter");
    }

    public void OnLookatExit()
    {
        Debug.Log("OnLookatExit");
    }

    public void OnLookatInteraction(Vector3 lookAtPosition, Vector3 lookAtDirection)
    {
        Debug.Log("OnLookatInteraction");
    }
}
