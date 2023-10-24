using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TeamSelect : MonoBehaviour
{

    public List<GameObject> allCreatedPlayers = new List<GameObject> { };

    PlayerData newPlayerRef;
    int newPlayerRefID;
    public int playerMadeCount;
    Canvas canvas;
    GameObject teamSelectionParent;
    GameObject playerButtonText;
    GameObject deletePlayerButton;
    GameObject renamePlayerButton; 
    GameObject playerButton;
    void Awake()
    {
        
        //Find the canvas in the scene and assigns it to the canvas field
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        teamSelectionParent = GameObject.Find("TeamSelection").gameObject;

//Find the prefab in the resources folder and assigns it to the playerButton field
playerButton = Resources.Load("Prefabs/Player Buttons") as GameObject;
         
    }

    // Update is called once per frame
    void Update()
    {
        playerMadeCount = this.gameObject.GetComponent<AddPlayerButtonReferences>().myTeam.teamPlayers.Count;
    }

    //This is a function attached to the add player game object (AddPlayerButtonReferences) and it's called by the
  public void AddNewPlayerOnPress()
    
        //Need to add autoselect of this button after a press
        //Need to pass all the references
        //Need to create the playerdata and assign them in the team inside the PGGT
        //Need to refine perfect alignment on X at least

    {
        if (playerMadeCount < 6)
        {

             //Add a count to how many players this button has created to limit it to 6 players per team.

             // playerMadeCount += 1;
             //Creating the Transformation information for the Instantiation
             Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;
            //Getting a reference to the team this PlayerButton works for
            TeamData currentTeam;
            currentTeam = this.gameObject.GetComponent<AddPlayerButtonReferences>().myTeam;

            //Creates a new PlayerData inside the current team (which contains a list of players among other things) and then store's the player's ID in newPlayerRefID
            newPlayerRefID = PersistentGlobalGameTracker.tracker.CreateNewPlayerOnTeam(currentTeam);
            //Instantating the button and getting a referrence to it
            GameObject instantiatedButton = Instantiate(playerButton, position, rotation);
            allCreatedPlayers.Add(instantiatedButton);
            //Assigning the canvas as a parent to the button so it's rendered properly
            instantiatedButton.transform.SetParent(teamSelectionParent.transform, false);
            //Setting the position of the PlayerButton to the right place
            Vector3 newPlayerPos = position;
            newPlayerPos.y += 30;
            newPlayerPos.x -= 80;
            instantiatedButton.transform.position = newPlayerPos;
            //Moving the "create new button" downwards 
            position.y -= 60.0f;
            this.gameObject.transform.position = position;

            instantiatedButton.GetComponent<PlayerButtonData>().myPosition = playerMadeCount+1;
            foreach (PlayerData player in currentTeam.teamPlayers)
            {
                if (player.playerID == newPlayerRefID) { newPlayerRef = player; }
            }
            for (int i = 0; i < instantiatedButton.transform.childCount; i++)
            {
                //Gets a reference to the deletePlayer button gameobject by looking through all the childs and finding the one that contains "delete"

                Transform child = instantiatedButton.transform.GetChild(i);
                if (child.name.Contains("Delete"))
                {
                    deletePlayerButton = child.gameObject;
                    deletePlayerButton.GetComponent<DeletePlayerButtonScript>().addPlayerButton = this.gameObject;
                    deletePlayerButton.GetComponent<DeletePlayerButtonScript>().myTeam = currentTeam;
                    deletePlayerButton.GetComponent<DeletePlayerButtonScript>().myPlayer = newPlayerRef;

                }
                //Gets a reference to the rename Player button gameobject by looking through all the childs and finding the one that contains "delete"

                if (child.name.Contains("Rename"))
                {
                    renamePlayerButton = child.gameObject;
                }
                if (child.name.Contains("Text"))
                {
                    playerButtonText = child.gameObject;
                }
            }
            instantiatedButton.GetComponent<PlayerButtonData>().myPlayerID = newPlayerRefID;

            instantiatedButton.GetComponent<PlayerButtonData>().myTeamID = currentTeam.teamID;

            //If it reaches the 6 players created during this creation, it makes the button inactive (still in the scene) in order to avoid creating to0 many players
            if (playerMadeCount >= 5) { this.gameObject.SetActive(false); EventSystem.current.SetSelectedGameObject(deletePlayerButton); }
            else
            {
                EventSystem.current.SetSelectedGameObject(this.gameObject);
            }





            //object reference not set to an instant of an object
            playerButtonText.GetComponent<ConnectNametoPGGT>().myPlayerButtonData = instantiatedButton.GetComponent<PlayerButtonData>();
            // playerButtonText.GetComponent<ConnectNametoPGGT>().mytext =


            // This will be creating NewPlayerData along with the playerButton and keep a reference to it: 
        }




    }

}


//The add player button needs a reference to the parent team, and a reference to the player which it will pass on to the change name, delete buttons, and to the player's team.
//It also needs a reference to the game objects Add button, delete button and the player prefab.