using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkToggle : MonoBehaviour
{
    [SerializeField] GameObject talker;
    [SerializeField] List<Toggle> toggles;

    public void Set(bool active)
    {
        foreach(Toggle toggle in toggles)
        {
            toggle.interactable = active;
        }
    }
}
