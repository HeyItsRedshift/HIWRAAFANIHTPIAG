using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    [SerializeField] private TMP_Text keyText;

    public void SetKey(string key)
    {
        keyText.text = key;
    }
}
