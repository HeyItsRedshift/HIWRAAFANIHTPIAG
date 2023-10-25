using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConnectMeToTheInput : MonoBehaviour
{
    GameObject keyboard;

   
    // Start is called before the first frame update
    void Start()
    {
        keyboard = GameObject.Find("Keyboard 2").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
            this.gameObject.GetComponent<TMP_Text>().text = keyboard.GetComponent<KeyboardInput>().input;
        
     
    }
}
