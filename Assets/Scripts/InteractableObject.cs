using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, ILookAtHandler
{
    // Start is called before the first frame update

    public void OnLookatEnter()
    {
        Debug.Log("Look");
    }

    public void OnLookatExit()
    {
        Debug.Log("no look");
    }

    public void OnLookatInteraction(Vector3 lookAtPosition, Vector3 lookAtDirection)
    {
        GameManager.Instance.SwitchScene();
    }
}
