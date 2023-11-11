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
        Vector3 positionOffset = addPlayerButton.GetComponent<RectTransform>().localPosition;
        RectTransform AddPlayerButtonTransformRect = addPlayerButton.GetComponent<RectTransform>();
        positionOffset.y += 230.0f;

        AddPlayerButtonTransformRect.localPosition = positionOffset;


        foreach (GameObject playerButton in addPlayerButton.GetComponent<TeamSelect>().allCreatedPlayers)
        {
            if (parentPlayerButton.GetComponent<PlayerButtonData>().myPosition <
                playerButton.GetComponent<PlayerButtonData>().myPosition)
            {
                RectTransform buttonPlayerButtonTransform = playerButton.GetComponent<RectTransform>();
                Vector3 buttonPositionOffset = playerButton.transform.position;
                buttonPositionOffset.x = -400;
                buttonPositionOffset.y = playerButton.GetComponent<RectTransform>().localPosition.y;
                buttonPositionOffset.y += 230f;
               
               playerButton.GetComponent<PlayerButtonData>().myPosition -= 1;
                buttonPlayerButtonTransform.localPosition = buttonPositionOffset;
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
