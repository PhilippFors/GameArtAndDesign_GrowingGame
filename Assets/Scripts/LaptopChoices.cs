using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopChoices : MonoBehaviour
{
    public GameObject gameScreen;
    public GameObject jobScreen;
    public GameObject homeworkScreen;
    public GameObject LaptopCanvas;
    public CameraController controller;

    private void Update()
    {
        if (GameManager.Instance.trashCollected & GameManager.Instance.bedMade)
        {
            LaptopCanvas.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (gameScreen.activeSelf)
            {
                gameScreen.SetActive(false);
            }
            if (jobScreen.activeSelf)
            {
                jobScreen.SetActive(false);
            }
            if (homeworkScreen.activeSelf)
            {
                homeworkScreen.SetActive(false);
            }
        }
        if (GameManager.Instance.playedGame & GameManager.Instance.jobSearch & GameManager.Instance.homeworkDone){
            Invoke("ShutPCdown", 2f);
        }
    }

    public void PlayGame()
    {
        if (!GameManager.Instance.playedGame)
        {
            GameManager.Instance.playedGame = true;
            gameScreen.SetActive(true);
        }

    }

    public void lookForJob()
    {
        if (!GameManager.Instance.jobSearch)
        {
            GameManager.Instance.jobSearch = true;
            jobScreen.SetActive(true);
        }
    }

    public void doHomework()
    {
        if (!GameManager.Instance.homeworkDone)
        {
            GameManager.Instance.homeworkDone = true;
            homeworkScreen.SetActive(true);
        }
    }

    public void ShutPCdown()
    {
        controller.SetLocked(false);
        
        
        UIManager.Instance.AddToSubtitleQueue("Man, I'm pooped. Guess it's bed time.");
        GameManager.Instance.SwitchScene();
    }
}
