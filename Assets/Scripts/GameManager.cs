using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CharacterController charcontrol;
    Vector3 vec = new Vector3(0, 2, 0);

    public bool sphereIn = false;
    public bool pyramidIn = false;
    public bool cubeIn = false;

    public bool toyBoxFilled = false;
    public bool homeworkDone = false;
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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        
    }

    public void Growing()
    {
        charcontrol.transform.Translate(vec);
        charcontrol.height = 1.6f;
    }

    public void SwitchScene()
    {
        if (toyBoxFilled)
        {
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        }
    }

    public void ToyBoxDone()
    {
        if(pyramidIn & cubeIn & sphereIn)
        {
            toyBoxFilled = true;
        }
    }
}
