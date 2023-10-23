using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] private TMP_Text keyText;

    public void SetKey(string key)
    {
        keyText.text = key;
=======
    [Header(" Elements ")]
    [SerializeField] private TMP_Text keyText;
=======
    [Header(" Elements ")]
    [SerializeField] private TMP_Text keyText;
>>>>>>> parent of b337145 (Keyboard more functionality ++)
    private string keyValue;  // Changed to string

    public void SetKey(string key)
    {
        this.keyValue = key;
        keyText.text = keyValue;

        if (key == "CAPS")
        {
            keyText.fontSize = keyText.fontSize * 0.5f;
        }
        else
        {
            keyText.fontSize = keyText.fontSize * 1f;
        }
    }

    public Button GetButton()
    {
        return GetComponent<Button>();
<<<<<<< HEAD
>>>>>>> parent of b337145 (Keyboard more functionality ++)
=======
>>>>>>> parent of b337145 (Keyboard more functionality ++)
    }
}
