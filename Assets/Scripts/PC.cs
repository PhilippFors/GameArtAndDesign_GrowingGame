using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public GameObject fpsController;
    public GameObject computerCam;
    public TMPro.TextMeshProUGUI buttonText;
    public Computercontroller camControl;
    int i = 0;

    void Start()
    {
        fpsController.SetActive(false);
        computerCam.SetActive(true);
        Invoke("TurnOnCursor", 0.5f);
    }

    // Update is called once per frame
   public void NextScreen()
    {
        string text;
        if (i < 5)
        {
            text = buttonText.text;
            text += "!";
            buttonText.text = text;
        }

        
   
        if(i >= 5 & !GameManager.Instance.workDone)
        {
            text = buttonText.text;
            text += "!!";
            buttonText.text = text;
        }

        if (i >= 8 & !GameManager.Instance.workDone)
        {
            text = buttonText.text;
            text += "!!!";
            buttonText.text = text;
        }

        if (i == 15)
        {
            GameManager.Instance.workDone = true;
            buttonText.text = "Work is done";
            camControl.SetLocked(false);
        }
        i++;
    }

    void TurnOnCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
   
}
