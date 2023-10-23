using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPressed : MonoBehaviour
{
    private Transform child;
    private string myLetter;
    private Transform parent;
    public void PressedKey()
    {
       child = this.transform.GetChild(0);
       myLetter = child.GetComponent<TMPro.TextMeshProUGUI>().text;
       parent = this.transform.parent;
       print(child);
       print(myLetter);
       print(parent);
       if(myLetter == "_")
        {
            parent.gameObject.GetComponent<KeyboardInput>().input += " ";
        }
       else if (myLetter == "<-")
        {
           
            if (parent.gameObject.GetComponent<KeyboardInput>().input.Length >= 1)
            {
                parent.gameObject.GetComponent<KeyboardInput>().input = parent.gameObject.GetComponent<KeyboardInput>().input.Substring(0, parent.gameObject.GetComponent<KeyboardInput>().input.Length - 1);
            }
        }
        else if (myLetter == "CAPS")
        {
        }
        else
        {
            parent.gameObject.GetComponent<KeyboardInput>().input += myLetter;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
