using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBear : MonoBehaviour, ILookAtHandler
{
    public MeshRenderer bear;
    public AudioSource baby;
    public void OnLookatEnter()
    {
        if (GameManager.Instance.workDone &!GameManager.Instance.lookedAtBear)
        {
            UIManager.Instance.AddToSubtitleQueue("That bear...", 4f);
            UIManager.Instance.AddToSubtitleQueue("I remember it from my childhood...");
            GameManager.Instance.lookedAtBear = true;
            Invoke("BabyCrying", 7f);
        }
    }

    public void OnLookatExit()
    {
        
    }

    public void OnLookatInteraction(Vector3 lookAtPosition, Vector3 lookAtDirection)
    {
        if (GameManager.Instance.lookedAtBear & !GameManager.Instance.tookBear)
        {
            bear.enabled = false;
            GameManager.Instance.tookBear = true;
        }
    }

    void BabyCrying()
    {
        baby.Play();
    }
    // Start is called before the first frame update
}
