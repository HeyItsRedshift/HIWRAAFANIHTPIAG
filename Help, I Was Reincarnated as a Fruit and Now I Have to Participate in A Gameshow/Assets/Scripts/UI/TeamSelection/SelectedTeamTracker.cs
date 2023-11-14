using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTeamTracker : MonoBehaviour
{
    public GameObject team1;
    public GameObject team2;
    public GameObject emptyTeam;
  [SerializeField]  public static List<GameObject> allAddedTeams = new List<GameObject> { };
    public static int currentTeamIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        IntitializeTeams();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject team in allAddedTeams) 
        {
            print(team.name);
            print(currentTeamIndex);
        }
    }


    void IntitializeTeams() { allAddedTeams.Add(team1); allAddedTeams.Add(team2); allAddedTeams.Add(emptyTeam); }
}
