using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Operator : MonoBehaviour
{
    [SerializeField] GameObject textObject;
    [SerializeField] float interval;
    List<string> dialogues = new();
    bool isPut = false;

    public void SetDialogues(OperateDialogue dialogue)
    {
        dialogues.AddRange(dialogue.GetDialogue());
    }

    private void FixedUpdate()
    {
        if(!isPut && dialogues.Count != 0)
        {
            StartCoroutine(nameof(Put));
        }
    }

    IEnumerator Put()
    {
        isPut = true;

        while(dialogues.Count != 0)
        {
            
            if(!float.TryParse(dialogues[0], out float f))
            {
                GameObject text = Instantiate(textObject, transform.position, Quaternion.identity);
                text.transform.SetParent(transform);
                text.GetComponent<TextMeshProUGUI>().text = dialogues[0];
            }
            dialogues.RemoveAt(0);
            Debug.Log(interval + f);
            yield return new WaitForSeconds(interval + f);
        }

        isPut = false;
    }
}
