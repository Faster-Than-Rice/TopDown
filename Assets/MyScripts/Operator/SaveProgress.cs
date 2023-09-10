using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    [SerializeField] Transform parent;

    private void Start()
    {
        SetProgress(int.MaxValue);
    }

    public void SetProgress(int progress)
    {
        PlayerPrefs.SetInt("Progress", progress);
    }

    public int GetProgress()
    {
        return PlayerPrefs.GetInt("Progress");
    }

    public void Update()
    {
        List<Transform> children = new();

        foreach (Transform child in parent)
        {
            children.Add(child);
            child.gameObject.SetActive(false);
        }

        for(int  counter = 0;counter <= Mathf.Clamp(GetProgress(), 0, children.Count - 1); counter++)
        {
            children[counter].gameObject.SetActive(true);
        }
    }
}
