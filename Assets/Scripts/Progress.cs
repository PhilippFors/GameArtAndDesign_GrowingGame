using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CharacterController charcontrol;
    private States state;
    Vector3 vec = new Vector3(0, 2, 0);
    void Start()
    {
        state = gameObject.GetComponent<States>();
    }

    public void Growing()
    {
        if (state.first)
        {
            charcontrol.transform.Translate(vec);
            charcontrol.height = 1.6f;
            state.first = false;
        }
    }
}
