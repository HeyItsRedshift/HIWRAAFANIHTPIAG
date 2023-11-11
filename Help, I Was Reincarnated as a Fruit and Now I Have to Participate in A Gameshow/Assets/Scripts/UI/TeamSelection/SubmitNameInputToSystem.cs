using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitNameInputToSystem : MonoBehaviour
{
    public enum TextInput
    {
        PlayerName,
        TeamName,
    }

   public TextInput selectedText;
    public GameObject teamParent;
   public GameObject doneButton;
    public GameObject keyboardParent;
    GameObject keyboard;
    public PlayerData myPlayer;
    public TeamData myTeam;
    // Start is called before the first frame update
    void Start()
    {
        keyboard = GameObject.Find("Keyboard 2").gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitInputToSystemAndReturn()
    {
        if (selectedText == TextInput.PlayerName) { myPlayer.playerName = keyboard.GetComponent<KeyboardInput>().input; if (teamParent != null) { teamParent.SetActive(true); } }
        if (selectedText == TextInput.TeamName) { myTeam.teamName = keyboard.GetComponent<KeyboardInput>().input; if (teamParent != null) { teamParent.SetActive(true); } }

        if (doneButton != null) { doneButton.SetActive(true); }
        if (keyboardParent != null) { keyboardParent.SetActive(false); }
    }
}
