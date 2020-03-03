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
    public bool workDone = false;
    public bool lookedAtBear = false;
    public bool tookBear = false;

    public Animator anim;


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

        _instance = this;

    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Level 1"))
        {
            currentLevel = 1;
        }
        if (SceneManager.GetActiveScene().name.Equals("Level 2"))
        {
            currentLevel = 2;
        }

        if (SceneManager.GetActiveScene().name.Equals("Level 3"))
        {
            currentLevel = 3;
        }
        PlayIntro();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        homeworkDone = false;
    }

    void PlayIntro()
    {
        
        anim.Play("Intro");
    }

    void PlayOutro()
    {
        anim.Play("Outro");
    }


    public void SwitchScene()
    {
        StartCoroutine(NextScene());
    }

    public IEnumerator NextScene()
    {
        if (SceneManager.GetActiveScene().name.Equals("Level 1"))
        {
            PlayOutro();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 2"))
        {
            PlayOutro();
            yield return new WaitForSeconds(2f);
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
