using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TypewriterModular : MonoBehaviour
{
    bool typing=false;
    bool finishedTyping=false;
    public List<string> slideShowTexts = new List<string>();
    public TMP_Text myText;
    private string test = "Your text goes here,Your text goes here,Your text goes here,Your text goes here";
    private float normalPauseBetweenChars = 0.01f;
    private float fastPauseBetweenChars = 0.001f;
    int i = 0;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        print(finishedTyping);

        SlideShowWithEnd(slideShowTexts);
    }



    void SlideShowWithEnd(List<string> textList) 
    { 
   
           

            if ((Input.GetButtonDown("A")) && !typing)
            {
                TypeWriteText(textList[i], (updatedText) =>
                {
                    myText.text = updatedText;
                    if (finishedTyping) { i++; }
                });
            }
       

    
    
    
    }

    void TypeWriteText(string input, Action<string> callback)
    {
        StartCoroutine(ShowText(input,finishedTyping ,callback));
       
    }

    public IEnumerator ShowText(string input,bool end, Action<string> callback)
    {
        float currentSpeed = normalPauseBetweenChars;
        bool released=false;
      
        typing = true;
        string updatedText = "";  // Local variable to store the gradually updated text
     
        foreach (char c in input)
        {
            // Append the current character to the updated text
            updatedText += c;

            // Determine the typing speed based on whether the Return key is pressed
            if (Input.GetButton("A") )
            {
           
            }
            else{ if (!released) { released = true; print("release"); } }

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
          




            // Invoke the callback function with the current progress
            callback(updatedText);

            yield return new WaitForSeconds(currentSpeed);
        }
       
        typing = false;
        // Do something with the final output string, if needed
        // In this example, you can also invoke the callback with the final output
        callback(updatedText);
    }
}
