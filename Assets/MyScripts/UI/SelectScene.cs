using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScene : MonoBehaviour
{
    string sceneName;
    [SerializeField] FadeScene fade;
    [SerializeField] string defaultName;

    private void Start()
    {
        sceneName = defaultName;
    }

    public void SetName(string name)
    { 
        sceneName = name;
    }

    public void Select()
    {
        fade.Load(sceneName);
    }
}
