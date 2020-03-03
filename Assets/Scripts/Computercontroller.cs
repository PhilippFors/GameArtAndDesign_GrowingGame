using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computercontroller : MonoBehaviour
{
    public GameObject fpscontroller;
  
    public GameObject computerCamera;
    public BoxCollider boxCol;

    public void SetLocked(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!locked)
        {
            Invoke("StopPC", 2f);

        }
    }
    public void StopPC()
    {
        fpscontroller.SetActive(true);
        computerCamera.SetActive(false);

        boxCol.enabled = false;


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}


