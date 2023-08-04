using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class FadeScene : MonoBehaviour
{
    [SerializeField] float delay;

    public void Load(int sceneNumber)
    {
        StartCoroutine(Scene(sceneNumber));
        GetComponent<Image>().raycastTarget = true;
    }

    IEnumerator Scene(int sceneNumber)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneNumber);
    }
}
