using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypwriterAndSlideShow : MonoBehaviour
{
    public static bool typing = false;
    bool finishedTyping = false;
    public List<string> slideShowTexts = new List<string>();
    public TMP_Text myText;
    private string test = "Your text goes here,Your text goes here,Your text goes here,Your text goes here";
    private float normalPauseBetweenChars = 0.01f;
    private float fastPauseBetweenChars = 0.001f;
    int i = 0;
    public delegate void typewriterDelegate();
    public static typewriterDelegate delegeteAtTheEnd;
    bool done=false;
    void Update()
    {
      
            SlideShowWithEnd(slideShowTexts);
    }

    void SlideShowWithEnd(List<string> textList)
    {
        if (i < textList.Count)
        {

            if (i==0 && !typing)
            {
                TypeWriteText(textList[i], (updatedText, end) =>
                {
                    myText.text = updatedText;
                    if (end) { i++; }
                });
            }

           else if ((Input.GetButtonDown("A")) && !typing)
            {
                TypeWriteText(textList[i], (updatedText, end) =>
                {
                    myText.text = updatedText;
                    if (end) { i++; }
                });
            }
        }
        else 
        {
            if ((Input.GetButtonDown("A")) && !typing)
            {
                if (delegeteAtTheEnd != null && !done)
                {
                    delegeteAtTheEnd.Invoke();
                    done = true;
                }
            }
        }
    }

    void TypeWriteText(string input, Action<string, bool> callback)
    {
        StartCoroutine(ShowText(input, callback));
    }

    public IEnumerator ShowText(string input, Action<string, bool> callback)
    {
        float currentSpeed = normalPauseBetweenChars;
        bool released = false;
        bool end = false;
        typing = true;
        string updatedText = "";

        foreach (char c in input)
        {
            updatedText += c;

            if (Input.GetButton("A"))
            {
                // Do something specific when the "A" button is held down
            }
            else
            {
                if (!released)
                {
                    released = true;
                }
            }

            if (released)
            {
                if (Input.GetButton("A"))
                {
                    currentSpeed = fastPauseBetweenChars;
                }
                else
                {
                    currentSpeed = normalPauseBetweenChars;
                }
            }

            
            callback(updatedText, end);

            yield return new WaitForSeconds(currentSpeed);
        }

        typing = false;
        end = true;
        callback(updatedText, end);
    }
}
