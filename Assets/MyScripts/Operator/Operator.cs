using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Operator : MonoBehaviour
{
    [SerializeField] GameObject textObject;
    [SerializeField] string eventTrigger;
    [SerializeField] float interval;
    List<string> dialogues = new();
    [SerializeField] UnityEvent dialogueEvent;
    bool isPut = false;

    public void SetDialogues(OperateDialogue dialogue)
    {
        dialogues.AddRange(dialogue.GetDialogue());
    }

    public void SetDialogue(string dialogue)
    {
        dialogues.Add(dialogue);
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
            if(dialogues[0] == eventTrigger)
            {
                dialogueEvent.Invoke();
                dialogues.RemoveAt(0);
            }
            else
            {
                if (!float.TryParse(dialogues[0], out float f))
                {
                    GameObject text = Instantiate(textObject, transform.localPosition, Quaternion.identity);
                    text.transform.SetParent(transform, false);
                    text.transform.localPosition = Vector3.zero;
                    text.GetComponent<TextMeshProUGUI>().text = dialogues[0];
                }
                dialogues.RemoveAt(0);
                yield return new WaitForSeconds(interval + f);
            }
        }

        isPut = false;
    }
}
