using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;
    float timer = 0;
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    [SerializeField]
    private float textSpeed = 0.01f;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        StartDialogue("Get to the end of the level as fast as possible using the new handy dandy explosion experiment! Use your left mouse click to create an explosion to push the player forward. Press the button below to get started!");
    }

    public void StartDialogue(string dialogue)
    {
        uiManager.dialoguePanel.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogue));
    }

    public IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            if (dialogueText.text.Length > 2)
            {
                string s = dialogueText.text.Substring(dialogueText.text.Length - 2);
                if (s == ".n" || s == "!n")
                {
                    dialogueText.text = "";
                }
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public IEnumerator ShowDialogueScreen(float seconds)
    {

        uiManager.dialoguePanel.SetActive(false);
        yield return new WaitForSeconds(seconds);
    }
}