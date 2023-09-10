using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;

public class MenuTalk : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string eventTrigger;
    [SerializeField] float clickDelay;
    [SerializeField] float firstDelay;
    [SerializeField] float textSpeed;
    [SerializeField] GameObject panel;
    [SerializeField] OperateDialogue firstDialogue;
    [SerializeField] UnityEvent dialogueEvent;
    List<string> talkDialogue = new();
    DOTweenAnimation tween;
    float clickCounter;
    float delay;

    private void Start()
    {
        tween = GetComponent<DOTweenAnimation>();
        if (firstDialogue != null)
        {
            Talk(firstDialogue);
            delay = talkDialogue[0].Length * textSpeed;
            text.DOText(talkDialogue[0], delay).SetEase(Ease.Linear).SetDelay(firstDelay);
            talkDialogue.RemoveAt(0);
            delay = talkDialogue[0].Length * textSpeed;
        }
    }

    public void Talk(OperateDialogue dialogue)
    {
        tween.DOPlayForward();
        panel.SetActive(true);
        foreach(string _text in dialogue.GetDialogue())
        {
            talkDialogue.Add(_text);
        }
        delay = talkDialogue[0].Length * textSpeed;
        text.DOText(talkDialogue[0], delay).SetEase(Ease.Linear);
        talkDialogue.RemoveAt(0);
        clickCounter = 0;
    }

    void Update()
    {
        clickCounter += Time.deltaTime;
    }

    public void Click()
    {
        if (clickCounter >= delay)
        {
            clickCounter = 0;
            text.text = "";

            if (talkDialogue[0] == eventTrigger)
            {
                dialogueEvent.Invoke();
                talkDialogue.RemoveAt(0);
                return;
            }
            delay = talkDialogue[0].Length * textSpeed;
            text.DOText(talkDialogue[0], delay).SetEase(Ease.Linear);
            talkDialogue.RemoveAt(0);
        }
    }
}
