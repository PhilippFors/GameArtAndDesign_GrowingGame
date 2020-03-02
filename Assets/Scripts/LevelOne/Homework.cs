using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homework : MonoBehaviour, ILookAtHandler
{

    public void OnLookatEnter()
    {
        if (!GameManager.Instance.homeworkDone & GameManager.Instance.toyBoxFilled)
        {
            UIManager.Instance.AddToSubtitleQueue("I don't want to do homework...", 4f);
            UIManager.Instance.AddToSubtitleQueue("But mum will yell at me if I don't do it");
        }

    }

    public void OnLookatExit()
    {

    }

    public void OnLookatInteraction(Vector3 lookAtPosition, Vector3 lookAtDirection)
    {
        if (!GameManager.Instance.homeworkDone & GameManager.Instance.toyBoxFilled)
        {
            UIManager.Instance.ShowSubtitle("Did the homework, time for bed.", true);
            GameManager.Instance.homeworkDone = true;
        }
    }
}
