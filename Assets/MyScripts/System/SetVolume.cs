using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider seSlider;
    [SerializeField] Slider bgmSlider;

    void FixedUpdate()
    {
        mixer.SetFloat("SE", seSlider.value);
        mixer.SetFloat("BGM", bgmSlider.value);
    }
}
