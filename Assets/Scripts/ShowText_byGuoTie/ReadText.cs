using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadText : MonoBehaviour
{

    public GameObject dialogueBox;  // display or hide the text box
    // public GameObject tips;         // tips // by 清梦微风
    public Text dialogueContent;    // the content of the dialogue
    public bool isEnabled = false;
    // public bool isTips = false;  // by 清梦微风
    public bool isClose = false;

    [TextArea(1, 4)]
    public string[] dialogueSentences;
    [SerializeField] private int theSentenceNum = 0;

    private void Start()
    {
        dialogueBox.SetActive(false);
        // tips.SetActive(false);   // by 清梦微风
        dialogueContent.text = dialogueSentences[theSentenceNum];
    }

    private void Update()
    {
        if (isClose)
        {
            dialogueBox.SetActive(false);
            isClose = false;
            theSentenceNum = 0;
            dialogueContent.text = dialogueSentences[theSentenceNum];
        }

        if (dialogueBox.activeInHierarchy)
        {
            if (theSentenceNum < dialogueSentences.Length)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    dialogueContent.text = dialogueSentences[theSentenceNum];
                    theSentenceNum++;
                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {   
                    dialogueBox.SetActive(false);
                    theSentenceNum = 0;
                    dialogueContent.text = dialogueSentences[theSentenceNum];
                }
            }
        }
        else
        {
            if (isEnabled)
            {
                isEnabled = false;
                dialogueBox.SetActive(true);
            }
        }

        // by 清梦微风
        //if (tips.activeInHierarchy)
        //{
        //    if (isTips == false)
        //    {
        //        tips.SetActive(false);
        //    }
        //}
        //else
        //{
        //    if (isTips)
        //    {
        //        isTips = false;
        //        tips.SetActive(true);
        //    }
        //}
    }

    public bool IsTalkEnd()
    {
        return theSentenceNum >= dialogueSentences.Length;
    }
}
