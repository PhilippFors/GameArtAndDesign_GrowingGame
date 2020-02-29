using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro sub;
    public int subtitleDuration = 5;

    public void SetSubtitle(string newText)
    {
        sub.text = newText;
        sub.gameObject.SetActive(true);
        Invoke("DisableSubtitle", subtitleDuration);
    }

    public void DisableSubtitle()
    {
        sub.gameObject.SetActive(false);
    }
}
