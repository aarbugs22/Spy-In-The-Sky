using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; private set; } //can set instance properties inside the script, other scripts can't change this

    [SerializeField] TMPro.TextMeshProUGUI messageText, yesText, noText;
    [SerializeField] GameObject panel;
    [SerializeField] Button yesButton, noButton;

    private List<string> currentMessages = new List<string>();
    private int msgId = 0;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    public void ShowMessages(List<string> messages, bool dialogue, List<Actions> yesActions = null, List<Actions> noActions = null, string yes = "Yes", string no = "No")
    {
        msgId = 0;

        yesButton.transform.parent.gameObject.SetActive(false);

        currentMessages = messages;

        panel.SetActive(true);

        if (dialogue)
        {
            yesText.text = yes;
            yesButton.onClick.RemoveAllListeners();
            yesButton.onClick.AddListener(delegate
            {
                panel.SetActive(false);

                if (yesActions != null)
                    AssignActionstoButtons(yesActions);
            });

            noText.text = no;
            noButton.onClick.RemoveAllListeners();
            noButton.onClick.AddListener(delegate
            {
                panel.SetActive(false);

                if (noActions != null)
                    AssignActionstoButtons(noActions);
            });
        }

        StartCoroutine(ShowMultipleMessages(dialogue));
    }

    IEnumerator ShowMultipleMessages(bool useDialogue)
    {
        messageText.text = currentMessages[msgId];

        while (msgId < currentMessages.Count)
        {
            if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0) && Extensions.IsMouseOverUI()))
            {
                msgId++;

                if (msgId < currentMessages.Count)
                    messageText.text = currentMessages[msgId];

                if (msgId == currentMessages.Count - 1)
                    yesButton.transform.parent.gameObject.SetActive(true);
            }

            yield return null;
        }

        if (!useDialogue)
            panel.SetActive(false);
    }

    void AssignActionstoButtons(List<Actions> actions)
    {
        List<Actions> localActions = actions;

        for (int i = 0; i < localActions.Count; i++)
        {
            localActions[i].Act();
        }
    }

    public void HideDialogue()
    {
        panel.SetActive(false);
    }
}
