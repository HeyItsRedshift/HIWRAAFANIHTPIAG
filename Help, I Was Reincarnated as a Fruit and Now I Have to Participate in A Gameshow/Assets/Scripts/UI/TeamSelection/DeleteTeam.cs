using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTeam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DeleteTeamOnPress() 
    {
        TeamData myTeam = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<TeamButtonData>().myTeam;
        GameObject myTeamGameObject;
        myTeamGameObject = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        SelectedTeamTracker.allAddedTeams.Remove(myTeamGameObject);
        PersistentGlobalGameTracker.tracker.teamlist.Remove(myTeam);
        if (SelectedTeamTracker.allAddedTeams.Count == SelectedTeamTracker.currentTeamIndex)
        { SelectedTeamTracker.allAddedTeams[SelectedTeamTracker.currentTeamIndex - 1].SetActive(true); SelectedTeamTracker.currentTeamIndex -= 1; print("previous en"); }
        else { SelectedTeamTracker.allAddedTeams[SelectedTeamTracker.currentTeamIndex].SetActive(true); print("next en"); }
        Destroy(this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject);



    }

}
