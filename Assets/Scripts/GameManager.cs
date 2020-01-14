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

    public bool toyboxdone = false;
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
    private void Update()
    {
        ToyBoxDone();
    }
    public void Growing()
    {
        charcontrol.transform.Translate(vec);
        charcontrol.height = 1.6f;
    }

    public void SwitchScene()
    {
        if (toyboxdone)
        {
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        }
    }

    public void ToyBoxDone()
    {
        if(pyramidIn & cubeIn & sphereIn)
        {
            toyboxdone = true;
        }
    }
}
