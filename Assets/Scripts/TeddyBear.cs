using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBear : MonoBehaviour, ILookAtHandler
{
    public MeshRenderer bear;
    public AudioSource baby;
    public AudioSource bglevel3;
    public AudioSource bglevel1;
    static float t = 0.0f;
    public void OnLookatEnter()
    {
        if (GameManager.Instance.workDone & !GameManager.Instance.lookedAtBear)
        {
            UIManager.Instance.AddToSubtitleQueue("That bear...", 4f);
            UIManager.Instance.AddToSubtitleQueue("I remember it from my childhood...");
            GameManager.Instance.lookedAtBear = true;
            Invoke("BabyCrying", 7f);
        }
    }

    private void Update()
    {
        if (GameManager.Instance.lookedAtBear)
        {
            bglevel1.volume = Mathf.Lerp(0.0f, 0.2f, t);
            bglevel3.volume = Mathf.Lerp(0.2f, 0.0f, t);



            t += 0.08f * Time.deltaTime;

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
            UIManager.Instance.AddToSubtitleQueue("Maybe the bear will calm down my kid.", 4f);
            UIManager.Instance.AddToSubtitleQueue("I'll get out of my room for now");
        }
    }

    void BabyCrying()
    {
        baby.Play();

    }
    // Start is called before the first frame update
}
