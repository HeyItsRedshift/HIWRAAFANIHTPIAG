using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewTeam : MonoBehaviour
{
    #region  References
    public GameObject newTeamPrefab;
    public GameObject emptyTeamParentPrefab;
    GameObject newEmptyeamParent;
    //References that need assignment upon creation
    public GameObject TeamSelectionEmptyParent;
    #endregion
    PersistentGlobalGameTracker pGGT;
    GameObject newTeam;
    // Start is called before the first frame update
    void Start()
    {
        pGGT = PersistentGlobalGameTracker.tracker;

        /*  Vector3 newPosition = buttonTransform.localPosition;
            newPosition.x = xOffset;
            newPosition.y = yOffset;
            buttonTransform.localPosition = newPosition;
            1168
*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNewTeam()
    {
       
        int newTeamID;
   
                //Creating the new team and setting the "Team Select" as it's parent so it's visible.
        newTeam = Instantiate(newTeamPrefab, Vector3.zero, Quaternion.identity);
        newTeam.transform.SetParent(TeamSelectionEmptyParent.transform,false);
        RectTransform TeamTransform = newTeam.GetComponent<RectTransform>();
        Vector3 newPosition = TeamTransform.localPosition;
        newPosition.y = 1168;
        TeamTransform.localPosition = newPosition;
            newTeamID  = pGGT.CreateNewTeam();
        newTeam.GetComponentInChildren<AddPlayerButtonReferences>().myTeamID = newTeamID;
        newTeam.GetComponentInChildren<AddPlayerButtonReferences>().myTeam = pGGT.findMyTeam(newTeamID);

        newTeam.GetComponentInChildren<TeamButtonData>().myTeamID = newTeamID;
        newTeam.GetComponentInChildren<RenameTeam>().myTeamID = newTeamID;
        // playerMadeCount = this.gameObject.GetComponent<AddPlayerButtonReferences>().myTeam.teamPlayers.Count;
        newTeam.GetComponentInChildren<TeamSelect>().playerMadeCount = newTeam.GetComponentInChildren<AddPlayerButtonReferences>().myTeam.teamPlayers.Count;
        newTeam.GetComponentInChildren<TeamSelect>().AddNewPlayerOnPress();
        newTeam.GetComponentInChildren<TeamSelect>().playerMadeCount = newTeam.GetComponentInChildren<AddPlayerButtonReferences>().myTeam.teamPlayers.Count;
        newTeam.GetComponentInChildren<TeamSelect>().AddNewPlayerOnPress();
        SelectedTeamTracker.allAddedTeams.Remove(this.gameObject.transform.parent.gameObject);
        SelectedTeamTracker.allAddedTeams.Add(newTeam);
        newEmptyeamParent = Instantiate(emptyTeamParentPrefab, Vector3.zero, Quaternion.identity);
        newEmptyeamParent.transform.SetParent(TeamSelectionEmptyParent.transform, false);
        SelectedTeamTracker.allAddedTeams.Add(newEmptyeamParent);
        newEmptyeamParent.SetActive(false);

        Destroy(this.gameObject);

    }
}
