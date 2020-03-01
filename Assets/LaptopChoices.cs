﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopChoices : MonoBehaviour
{
    public GameObject gameScreen;
    public GameObject jobScreen;
    public GameObject homeworkScreen;

    private void Update()
    {
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
}
