using UnityEngine;
using TMPro; // Add this at the top
using UnityEngine.UI;

public class TeamNameChangeHandler : MonoBehaviour
{
    public Keyboard keyboard;
    public Button changeTeam1NameButton;
    public TMP_Text changeTeam1NameButtonText;  // Change Text to TMP_Text
    public Button changeTeam2NameButton;
    public TMP_Text changeTeam2NameButtonText;  // Change Text to TMP_Text

    void Start()
    {
        changeTeam1NameButton.onClick.AddListener(() => ToggleKeyboard(changeTeam1NameButtonText));
        changeTeam2NameButton.onClick.AddListener(() => ToggleKeyboard(changeTeam2NameButtonText));
    }

    void ToggleKeyboard(TMP_Text buttonText)  // Update here as well
    {
        keyboard.ToggleKeyboard();

        if (keyboard.gameObject.activeSelf)
        {
            buttonText.text = "DONE";
        }
        else
        {
            buttonText.text = "Change name";
        }
    }
}
