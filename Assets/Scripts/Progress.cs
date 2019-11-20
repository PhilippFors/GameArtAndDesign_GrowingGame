using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CharacterController charcontrol;
    private States state;
    void Start()
    {
        state = gameObject.GetComponent<States>();
    }

    public void Growing()
    {
        if (state.first)
        {
            
            charcontrol.height = 1f;
            state.first = false;
        }
    }
}
