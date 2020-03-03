using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("FPSController") & GameManager.Instance.tookBear)
        {
            anim.Play("End");
            Invoke("QuitGame", 5f);
        }
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
