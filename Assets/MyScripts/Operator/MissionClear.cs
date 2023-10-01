using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionClear : MonoBehaviour
{
    [SerializeField] int progressValue;

    private void Start()
    {
        if(SaveProgress.GetProgress() < progressValue)
        SaveProgress.SetProgress(progressValue);
    }
}
