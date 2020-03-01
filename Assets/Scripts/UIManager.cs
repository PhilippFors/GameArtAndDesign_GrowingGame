using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI sub;
    public int subtitleDuration = 5;
    public string[] subtitles = new string[10];

    private static UIManager _instance;
    public static UIManager Instance
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
    public void ShowSubtitle(string newText, bool deleteQueue)
    {
        sub.text = newText;
        sub.gameObject.SetActive(true);
        if (deleteQueue)
        {
            Invoke("DisableSubtitle", 5f);
            int j = 0;
            while (j < subtitles.Length)
            {
                if (subtitles[j] != "")
                {
                    subtitles[j] = "";
                }
                j++;
            }
            StopCoroutine("PlaySubtitles");
        }
    }

    public void AddToSubtitleQueue(string text, float interval = 5f)
    {
        StopCoroutine("PlaySubtitles");
        CancelInvoke("DisableSubtitle");
        int i = 0;
        int j = 0;
        bool dup = false;
        while (j < subtitles.Length)
        {
            if (subtitles[j] == text)
            {
                dup = true;
            }
            j++;
        }

        while (!dup & i < subtitles.Length)
        {
            if (subtitles[i] == "")
            {
                subtitles[i] = text;
                dup = true;
            }
            i++;
        }
        StartCoroutine("PlaySubtitles", interval);
    }

    private IEnumerator PlaySubtitles(float interval)
    {

        int i = 0;

        while (i < subtitles.Length)
        {
            float timesum = 0;
            if (subtitles[i] != "")
            {
                ShowSubtitle(subtitles[i], false);
            }
            while (timesum < interval)
            {
                timesum = timesum + Time.deltaTime;
            }
            yield return new WaitForSeconds(interval);
            DisableSubtitle(i);
            i++;
        }
        yield return null;
    }

    public void DisableSubtitle()
    {
        sub.gameObject.SetActive(false);
    }
    public void DisableSubtitle(int i)
    {
        sub.gameObject.SetActive(false);
        subtitles[i] = "";
    }
}
