using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverScreenSpawner : MonoBehaviour
{
    [SerializeField] GameObject overScreen;

    private void Start()
    {
        GameObject instance = Instantiate(overScreen, GameObject.FindGameObjectWithTag("Canvas").transform.position, Quaternion.identity);
        instance.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        instance.GetComponent<OverScreen>().SetTarget(gameObject.transform);
        instance.transform.SetAsFirstSibling();
        if (GameObject.Find("HUD"))
            instance.transform.SetParent(GameObject.Find("HUD").transform);
    }
}
