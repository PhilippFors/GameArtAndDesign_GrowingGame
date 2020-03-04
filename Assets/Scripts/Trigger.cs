using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public BoxCollider goalcol;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals(ball.name) & !GameManager.Instance.homeworkDone)
        {
            GameManager.Instance.goooooooal = true;
            UIManager.Instance.AddToSubtitleQueue("Gooooooooal!!!!", 3f);
            UIManager.Instance.AddToSubtitleQueue("Is it time for homework already", 3f);

            goalcol.isTrigger = false;
        }
        else if (other.gameObject.name.Equals(ball.name) & GameManager.Instance.homeworkDone)
        {

                GameManager.Instance.goooooooal = true;
                UIManager.Instance.AddToSubtitleQueue("Gooooooooal!!!!", 3f);
                UIManager.Instance.AddToSubtitleQueue("I'm tired now. I'm going to bed.", 3f);

        }


    }
}
