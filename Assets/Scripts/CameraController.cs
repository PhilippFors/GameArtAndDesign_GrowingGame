using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float mainSpeed = 10.0f; //regular speed
    public bool lockedIn = false;
    private Computer computer;
    [SerializeField] Camera fpsCamera;
    [SerializeField] Camera pcCamera;
    Vector3 positionBeforeEntering;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In trigger");
        computer = other.GetComponent<Computer>();

        if (computer)
        {
            SetLocked(true);
        }
    }

    private void Start()
    {
        pcCamera.enabled = false;
        fpsCamera.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        if (lockedIn)
        {

            //Keyboard commands
            // Vector3 p = GetBaseInput();

            //     p = p * mainSpeed;
            //
            //
            //     p = p * Time.deltaTime;
            //     Vector3 newPosition = transform.position;
            //     if (Input.GetKey(KeyCode.Space))
            //     { //If player wants to move on X and Z axis only
            //         transform.Translate(p);
            //         newPosition.x = transform.position.x;
            //         newPosition.z = transform.position.z;
            //         transform.position = newPosition;
            //     }
            //     else
            //     {
            //         transform.Translate(p);
            //     }
            // }
            // else
            // {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Escape))
            {
                SetLocked(false);
            }
        }
    }

    //private Vector3 GetBaseInput()
    //{ //returns the basic values, if it's 0 than it's not active.
    //    Vector3 p_Velocity = new Vector3();
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        p_Velocity += new Vector3(0, 0, 1);
    //    }
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        p_Velocity += new Vector3(0, 0, -1);
    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        p_Velocity += new Vector3(-1, 0, 0);
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        p_Velocity += new Vector3(1, 0, 0);
    //    }
    //    return p_Velocity;
    //}

    public void SetLocked(bool locked)
    {
        lockedIn = locked;

        if (locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pcCamera.eventMask = 5;
            pcCamera.enabled = true;
            fpsCamera.enabled = false;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            pcCamera.enabled = false;
            fpsCamera.enabled = true;

        }
    }
}
