using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   void AddPlayerButtontoTeam() 
    
    {
        TeamData currentTeam;
        currentTeam = this.gameObject.GetComponent<AddPlayerButtonReferences>().myTeam;
      // newplayerref = PersistentGlobalGameTracker.tracker.CreateNewPlayerOnTeam(currentTeam);


    }

}
