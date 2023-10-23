using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerButtonReferences : MonoBehaviour
{//These are the references script that is attached on the add player button

   public TeamData myTeam;
   public int myTeamID; //The player button gets a reference to it's team's ID either manual (for the first two teams) or by assignment during creation (On create team button).
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //Checks and fetces a reference to the actual TeamData by using the ID.
        if (PersistentGlobalGameTracker.tracker.teamlist != null)
        {
            myTeam = PersistentGlobalGameTracker.tracker.teamlist.Find(team => team.teamID == myTeamID);
        }
    }
}
