using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FadeScene : MonoBehaviour
{
    [SerializeField] float delay;

    public void Load(int sceneNumber)
    {
        StartCoroutine(Scene(sceneNumber));
    }

    IEnumerator Scene(int sceneNumber)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneNumber);
    }
}
