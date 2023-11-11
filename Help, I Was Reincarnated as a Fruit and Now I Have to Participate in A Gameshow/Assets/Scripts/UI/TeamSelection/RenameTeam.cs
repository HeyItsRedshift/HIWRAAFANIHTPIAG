using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenameTeam : MonoBehaviour
{
    public PlayerData myPlayer;
    public int myPlayerID; //will need to be assigned bia code on creation
    public int myTeamID;//will need to be assigned bia code on creation
    TeamData myTeam;
    GameObject teamParent;//will need to be assigned bia code on creation
    GameObject doneButton;//will need to be assigned bia code on creation
    public GameObject submitNameButton; //will need to be assigned bia code on creation
    public GameObject keyboardParent;//will need to be assigned bia code on creation

    // Start is called before the first frame update
    void Start()
    {

        myTeam = PersistentGlobalGameTracker.tracker.findMyTeam(myTeamID);
        myPlayer = PersistentGlobalGameTracker.tracker.findMyPlayer(myPlayerID, myTeam);
        teamParent = GameObject.Find("Team").gameObject;
        doneButton = GameObject.Find("Done Button").gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchViewToKeyboard()
    {
        myTeam = PersistentGlobalGameTracker.tracker.findMyTeam(myTeamID);
        myPlayer = PersistentGlobalGameTracker.tracker.findMyPlayer(myPlayerID, myTeam);


        if (keyboardParent != null)
        {
            keyboardParent.SetActive(true);

        }
        submitNameButton.GetComponent<SubmitNameInputToSystem>().selectedText = SubmitNameInputToSystem.TextInput.TeamName;
        submitNameButton.GetComponent<SubmitNameInputToSystem>().myTeam = myTeam;
        keyboardParent.transform.GetComponentInChildren<KeyboardInput>().input = myTeam.teamName;
        if (teamParent != null) { teamParent.SetActive(false); }
        if (doneButton != null) { doneButton.SetActive(false); }

    }
}
