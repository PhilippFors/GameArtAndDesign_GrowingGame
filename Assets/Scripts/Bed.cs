using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, ILookAtHandler
{
    public void OnLookatEnter()
    {
        if (GameManager.Instance.currentLevel == 2 & !GameManager.Instance.bedMade)
            UIManager.Instance.ShowSubtitle("Make the bed? I'm not a child anymore.", true);
    }

    public void OnLookatExit()
    {

    }

    public void OnLookatInteraction(Vector3 lookAtPosition, Vector3 lookAtDirection)
    {
        if (GameManager.Instance.currentLevel == 1)
        {
            if (GameManager.Instance.homeworkDone & GameManager.Instance.toyBoxFilled & GameManager.Instance.goooooooal)
                GameManager.Instance.SwitchScene();
        }
        if (GameManager.Instance.currentLevel == 2 & !GameManager.Instance.bedMade)
        {
            UIManager.Instance.AddToSubtitleQueue("Ugh, made the bed I guess.");
            GameManager.Instance.bedMade = true;
            UIManager.Instance.AddToSubtitleQueue("Why do I need to pick up the trash too?", 6f);
            UIManager.Instance.AddToSubtitleQueue("My room is fine the way it is.");
        }
    }

}
