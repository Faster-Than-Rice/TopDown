using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMute : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] string paramName;

    public void Mute(bool isMute)
    {
        if (isMute)
            mixer.SetFloat(paramName, -80);
        else
            mixer.SetFloat(paramName, AudioManager.volume);
    }
}
