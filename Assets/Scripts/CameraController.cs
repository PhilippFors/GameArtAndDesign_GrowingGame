using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float mainSpeed = 10.0f; //regular speed
    bool lockedIn = false;
    private Computer computer;
    Vector3 positionBeforeEntering;

    private void OnTriggerEnter(Collider other)
    {
        computer = other.GetComponent<Computer>();

        if(computer)
        {
            SetLocked(true);
        }
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (!lockedIn)
        {

            //Keyboard commands
            Vector3 p = GetBaseInput();

            p = p * mainSpeed;


            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            if (Input.GetKey(KeyCode.Space))
            { //If player wants to move on X and Z axis only
                transform.Translate(p);
                newPosition.x = transform.position.x;
                newPosition.z = transform.position.z;
                transform.position = newPosition;
            }
            else
            {
                transform.Translate(p);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Escape))
            {
                SetLocked(false);
            }
        }
    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }

    public void SetLocked(bool locked)
    {
        lockedIn = locked;

        if (locked)
        {
            positionBeforeEntering = transform.position;
            transform.position = computer.restPosition.position;
            Cursor.visible = true;
        }
        else
        {
            transform.position = positionBeforeEntering;
            Cursor.visible = false;
        }
    }
}
