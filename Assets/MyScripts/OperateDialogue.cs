using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue", fileName = "New Dialogue")]
public class OperateDialogue : ScriptableObject
{
    [TextArea, SerializeField] List<string> dialogues;

    public List<string> GetDialogue()
    {
        return dialogues;
    }
}
