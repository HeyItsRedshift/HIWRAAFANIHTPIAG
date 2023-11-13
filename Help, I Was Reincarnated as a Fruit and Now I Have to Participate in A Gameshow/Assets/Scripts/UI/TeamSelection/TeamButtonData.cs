using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamButtonData : MonoBehaviour
{
  
        public AddPlayerButtonReferences myAddPlayerButtonReferences;

        public int myTeamID;
        public TeamData myTeam;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        myTeam = PersistentGlobalGameTracker.tracker.findMyTeam(myTeamID);
        }
    }