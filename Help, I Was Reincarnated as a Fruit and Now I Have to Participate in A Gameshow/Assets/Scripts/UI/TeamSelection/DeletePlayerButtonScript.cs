using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeletePlayerButtonScript : MonoBehaviour
{
    int myIndex;
    public PlayerButtonData myPlayerButtonData;
    public PlayerData myPlayer;
    public TeamData myTeam;
    public GameObject addPlayerButton;
    public GameObject parentPlayerButton;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        myPlayer = myPlayerButtonData.myPlayer;
        myTeam = myPlayerButtonData.myTeam;
    }

    public void DeletePlayerWhenPressed() 
    {

        addPlayerButton.GetComponent<TeamSelect>().playerMadeCount -= 1;
        if (!addPlayerButton.activeSelf) { addPlayerButton.SetActive(true); }
        Vector3 position = addPlayerButton.transform.position;
        position.y += 60.0f;
        addPlayerButton.transform.position = position;
        foreach (GameObject playerButton in addPlayerButton.GetComponent<TeamSelect>().allCreatedPlayers)
        {
            if (parentPlayerButton.GetComponent<PlayerButtonData>().myPosition <
                playerButton.GetComponent<PlayerButtonData>().myPosition)
            {

                Vector3 buttonPosition = playerButton.transform.position;
                buttonPosition.y += 60f;
               playerButton.GetComponent<PlayerButtonData>().myPosition -= 1;
                playerButton.transform.position = buttonPosition;

            }
        }

 


        addPlayerButton.GetComponent<TeamSelect>().allCreatedPlayers.Remove(parentPlayerButton);

        foreach (TeamData team in PersistentGlobalGameTracker.tracker.teamlist) 
        {

           if (team == myTeam) { team.teamPlayers.Remove(myPlayer); }

        }
        //PersistentGlobalGameTracker.tracker.teamlist
        EventSystem.current.SetSelectedGameObject(addPlayerButton);
        Destroy(parentPlayerButton);
    
    }
}
