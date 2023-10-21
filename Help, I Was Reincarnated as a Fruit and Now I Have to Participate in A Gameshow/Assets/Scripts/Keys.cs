using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Keys : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TMP_Text keyText;
    private char key;

    public void SetKey(char key)
    {
        this.key = key;
        keyText.text = key.ToString();
    }
    public Button GetButton()
    {
        return GetComponent<Button>();
    }
}
