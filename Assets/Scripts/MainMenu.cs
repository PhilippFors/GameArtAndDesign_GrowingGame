using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public bool creditsactive = false;
    public GameObject mainPage;
    public GameObject creditsPage;
    public Animator anim;
    public void PlayGame()
    {
        anim.Play("Outro");
        Invoke("SwitchScene", 2f);
        
    }

    void SwitchScene()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        if (!creditsactive)
        {
            mainPage.SetActive(false);
            creditsPage.SetActive(true);
        }
        else
        {
            mainPage.SetActive(true);
            creditsPage.SetActive(false);
        }
        creditsactive = !creditsactive;
    }
}
