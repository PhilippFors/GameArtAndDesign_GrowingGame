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
    public bool goooooooal = false;

    public bool bedMade = false;
    public bool trashCollected = false;
    public bool playedGame = false;
    public bool jobSearch = false;


    public int currentLevel = 1;
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
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        homeworkDone = false;
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
        currentLevel++;
        if (SceneManager.GetActiveScene().name.Equals("Level 1"))
        {
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 2"))
        {
            SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
        }
    }

    public void ToyBoxDone()
    {
        if (pyramidIn & cubeIn & sphereIn)
        {
            toyBoxFilled = true;
        }
    }
}
