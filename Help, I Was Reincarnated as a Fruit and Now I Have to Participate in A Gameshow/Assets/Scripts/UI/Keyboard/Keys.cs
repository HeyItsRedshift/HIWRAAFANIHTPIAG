using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keys : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TMP_Text keyText;

    private string keyValue;
    private bool isCapsActive = false;

    public void SetKey(string key)
    {
        this.keyValue = key;
        keyText.text = key;

        // Adjust text size for special keys
        if (key == "CAPS")
        {
            keyText.fontSize = keyText.fontSize * 0.6f; // Adjust as necessary
        }
    }

    public Button GetButton()
    {
        return GetComponent<Button>();
    }

    public void ToggleCaps()
    {
        if (keyValue.Length == 1)  // assuming other special keys will have length > 1
        {
            isCapsActive = !isCapsActive;
            if (isCapsActive)
            {
                keyText.text = keyValue.ToUpper();
            }
            else
            {
                keyText.text = keyValue.ToLower();
            }
        }
    }
}
