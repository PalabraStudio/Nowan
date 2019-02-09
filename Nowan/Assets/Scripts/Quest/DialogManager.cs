using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialog;
    private Queue<string> sentenses;
    public GameObject dialogBox;

    // Start is called before the first frame update
    void Start()
    {
        sentenses = new Queue<string>();
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    public void StartDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        Time.timeScale = 0;
        sentenses.Clear();
        foreach(string sentense in dialog.dialog)
        {
            sentenses.Enqueue(sentense);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentenses.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentenses.Dequeue();
        dialog.text = sentence;
    }

    public void EndDialogue()
    {
        dialogBox.SetActive(false);
        Time.timeScale = 1;
    }

}
