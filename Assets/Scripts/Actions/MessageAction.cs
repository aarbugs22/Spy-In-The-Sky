using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAction : Actions
{
    [Multiline(5)]
    [SerializeField] List<string> message;
    [SerializeField] bool enableDialogue;
    [SerializeField] string yesText, noText;
    [SerializeField] List<Actions> yesActions, noActions;

    public override void Act()
    {
        //Debug.Log(message);
        DialogueSystem.Instance.ShowMessages(message, enableDialogue, yesActions, noActions, yesText, noText);
    }
}
