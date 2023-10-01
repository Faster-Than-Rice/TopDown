using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;

    private void Start()
    {
        for(int count = 0;count < buttons.Length;count++)
        {
            buttons[count].SetActive(count <= GetProgress());
        }
    }

    public static void SetProgress(int progress)
    {
        PlayerPrefs.SetInt("Progress", progress);
        PlayerPrefs.Save();
    }

    public static int GetProgress()
    {
        return PlayerPrefs.GetInt("Progress", 0);
    }
}
