using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CharacterController charcontrol;
    Vector3 vec = new Vector3(0, 2, 0);


    //Singleton Setup
    //Call Methods or Variables with GameManager.Instance.Method()/Variable
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Null");

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    public void Growing()
    {
        charcontrol.transform.Translate(vec);
        charcontrol.height = 1.6f;
    }
}
