using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;

    private void Start()
    {
        SaveManager.Save();
        for(int count = 0;count < buttons.Length;count++)
        {
            buttons[count].SetActive(count <= GetProgress());
        }
    }

    public static void SetProgress(int progress)
    {
        SaveManager.save.progress = progress;
    }

    public static int GetProgress()
    {
        return SaveManager.save.progress;
    }
}
