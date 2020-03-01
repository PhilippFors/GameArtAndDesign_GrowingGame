using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float mainSpeed = 10.0f; //regular speed
    bool lockedIn = false;
    private Computer computer;
    Vector3 positionBeforeEntering;
    public GameObject fpscontroller;
    public GameObject fpsCamera;
    public GameObject laptopCamera;
    public BoxCollider boxCol;

    public bool inTrigger = false;
    public void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name.Equals(fpscontroller.name) & GameManager.Instance.trashCollected)
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
        lockedIn = locked;

        if (locked)
        {
            positionBeforeEntering = fpscontroller.transform.position;
            
            fpscontroller.SetActive(false);
            laptopCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            fpscontroller.transform.position = positionBeforeEntering;
            fpscontroller.SetActive(true);
            laptopCamera.SetActive(false);
            boxCol.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
