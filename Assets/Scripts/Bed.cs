using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, ILookAtHandler
{
    // Start is called before the first frame update

    public void OnLookatEnter()
    {
       
    }

    public void OnLookatExit()
    {
        
    }

    public void OnLookatInteraction(Vector3 lookAtPosition, Vector3 lookAtDirection)
    {
        if(GameManager.Instance.homeworkDone)
        GameManager.Instance.SwitchScene();
    }
}
