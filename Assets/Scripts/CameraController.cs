using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 positionBeforeEntering;
    public GameObject fpscontroller;
    public GameObject fpsCamera;
    public GameObject laptopCamera;
    public BoxCollider boxCol;

    public bool inTrigger = false;
    public void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        if (other.gameObject.name.Equals(fpscontroller.name) & GameManager.Instance.trashCollected & GameManager.Instance.bedMade)
        {
            SetLocked(true);
            inTrigger = true;
        }
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Escape))
        {
            SetLocked(false);
        }

    }

    public void SetLocked(bool locked)
    {

        if (locked)
        {
            fpscontroller.SetActive(false);
            laptopCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            fpscontroller.SetActive(true);
            laptopCamera.SetActive(false);
            if (GameManager.Instance.playedGame & GameManager.Instance.jobSearch & GameManager.Instance.homeworkDone)
            {
                boxCol.enabled = false;
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
