using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanTrigger : MonoBehaviour
{
    public int trashIn = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        trashIn++;
        if (trashIn == 3)
        {

            if (!GameManager.Instance.bedMade)
            {
                UIManager.Instance.AddToSubtitleQueue("All of the trash is in the bin.", 4f);
                UIManager.Instance.AddToSubtitleQueue("Gotta make my bed too, I guess.");

            }
            else
            {
                UIManager.Instance.AddToSubtitleQueue("All of the trash is in the bin.", 4f);
                UIManager.Instance.AddToSubtitleQueue("Now it's PC time!");
            }
            GameManager.Instance.trashCollected = true;

        }
    }
}
