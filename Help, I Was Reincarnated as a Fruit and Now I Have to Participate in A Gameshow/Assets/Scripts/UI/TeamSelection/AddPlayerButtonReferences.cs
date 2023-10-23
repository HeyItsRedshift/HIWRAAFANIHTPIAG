using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerButtonReferences : MonoBehaviour
{
   public TeamData myTeam;
   public int myTeamID;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (PersistentGlobalGameTracker.tracker.teamlist != null)
        {
            myTeam = PersistentGlobalGameTracker.tracker.teamlist.Find(team => team.teamID == myTeamID);
        }
    }
}
