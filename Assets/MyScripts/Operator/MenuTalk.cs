using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;

public class MenuTalk : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float interval;
    [SerializeField] string eventTrigger;
    [SerializeField] UnityEvent dialogueEvent;
    [SerializeField] AudioClip clip;
    DOTweenAnimation tween;
    AudioSource source;
    List<string> talkDialogue = new();

    private void Start()
    {
        tween = text.GetComponent<DOTweenAnimation>();
        source = GetComponent<AudioSource>();
    }

    public void Talk(OperateDialogue dialogue)
    {
        foreach(string _text in dialogue.GetDialogue())
        {
            talkDialogue.Add(_text);
        }
      
        StartCoroutine(nameof(Put));
    }

    IEnumerator Put()
    {
        yield return new WaitForSeconds(0.5f);
        while(talkDialogue.Count != 0)
        {
            if(talkDialogue[0] == eventTrigger)
            {
                dialogueEvent.Invoke();
                talkDialogue.RemoveAt(0);
                continue;
            }

            float delay = talkDialogue[0].Length * 0.1f;
            text.DOText(talkDialogue[0], delay).SetEase(Ease.Linear);
            source.PlayOneShot(clip);
            talkDialogue.RemoveAt(0);

            yield return new WaitForSeconds(delay + interval / 2);

            text.text = "";

            yield return new WaitForSeconds(interval / 2);
        }
    }
}
