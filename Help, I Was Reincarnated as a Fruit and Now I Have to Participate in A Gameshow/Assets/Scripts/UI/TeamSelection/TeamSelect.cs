using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSelect : MonoBehaviour
{
    public int playerMadeCount;
    Canvas canvas;
    GameObject playerButton;
    void Awake()
    {
        //Find the canvas in the scene and assigns it to the canvas field
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //Find the prefab in the resources folder and assigns it to the playerButton field
        playerButton = Resources.Load("Prefabs/Player Buttons") as GameObject;
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This is a function attached to the add player game object (AddPlayerButtonReferences) and it's called by the
  public void AddNewPlayerOnPres()
    
        //need to add: Reference of this button to delete buttons and then they can also manage the "PlayerMadeCount" and they can activate this button
        //Need to add autoselect of this button after a press
        //Need to pass all the references
        //Need to create the playerdata and assign them in the team inside the PGGT
        //Need to refine perfect alignment on X at least

    {
        if (playerMadeCount < 6)
        {
            //Add a count to how many players this button has created to limit it to 6 players per team.
            playerMadeCount += 1;
            //Creating the Transformation information for the Instantiation
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;
            //Getting a reference to the team this PlayerButton works for
            TeamData currentTeam;
            currentTeam = this.gameObject.GetComponent<AddPlayerButtonReferences>().myTeam;
            //Instantating the button and getting a referrence to it
            GameObject instantiatedButton = Instantiate(playerButton, position, rotation);
            //Assigning the canvas as a parent to the button so it's rendered properly
            instantiatedButton.transform.SetParent(canvas.transform, false);
            //Setting the position of the PlayerButton to the right place
            Vector3 newPlayerPos = position;
            newPlayerPos.y += 30;
            newPlayerPos.x -= 80;
            instantiatedButton.transform.position = newPlayerPos;
            //Moving the "create new button" downwards 
            position.y -= 60.0f;
            this.gameObject.transform.position = position;
            //If it reaches the 6 players created during this creation, it makes the button inactive (still in the scene) in order to avoid creating to0 many players
            if (playerMadeCount>=6) { this.gameObject.SetActive(false); }


            // This will be creating NewPlayerData along with the playerButton and keep a reference to it: newplayerref = PersistentGlobalGameTracker.tracker.CreateNewPlayerOnTeam(currentTeam);
        }




    }

}


//The add player button needs a reference to the parent team, and a reference to the player which it will pass on to the change name, delete buttons, and to the player's team.
//It also needs a reference to the game objects Add button, delete button and the player prefab.