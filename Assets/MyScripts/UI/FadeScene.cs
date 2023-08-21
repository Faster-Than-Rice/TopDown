using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class FadeScene : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] DOTweenAnimation fadeAnimation;

    public void Load(string sceneName)
    {
        StartCoroutine(Scene(sceneName));
        GetComponent<Image>().raycastTarget = true;
        fadeAnimation.DOPlayBackwards();
    }

    IEnumerator Scene(string sceneName)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }
}
