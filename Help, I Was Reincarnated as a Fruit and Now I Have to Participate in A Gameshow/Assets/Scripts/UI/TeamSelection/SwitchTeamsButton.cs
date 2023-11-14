using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTeamsButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

   public void TeamSwitchOnPress() 
    {
        if (this.gameObject.name.Contains("Previous")) 
        {
            if (SelectedTeamTracker.currentTeamIndex >= 1)
            {
                SelectedTeamTracker.allAddedTeams[SelectedTeamTracker.currentTeamIndex].SetActive(false);
                SelectedTeamTracker.allAddedTeams[SelectedTeamTracker.currentTeamIndex-1].SetActive(true);
                SelectedTeamTracker.currentTeamIndex -= 1; 
            }

        }

        if (this.gameObject.name.Contains("Next"))
        {
            if (SelectedTeamTracker.currentTeamIndex+1 < SelectedTeamTracker.allAddedTeams.Count)
            {
                SelectedTeamTracker.allAddedTeams[SelectedTeamTracker.currentTeamIndex].SetActive(false);
                SelectedTeamTracker.allAddedTeams[SelectedTeamTracker.currentTeamIndex + 1].SetActive(true);
                SelectedTeamTracker.currentTeamIndex += 1;
            }
        }

    }
}
