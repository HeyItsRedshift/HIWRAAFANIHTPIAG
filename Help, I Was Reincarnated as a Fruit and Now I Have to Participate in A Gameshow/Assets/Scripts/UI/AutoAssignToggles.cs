using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AutoAssignToggles : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = this.gameObject.GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name.Contains("1")) 
        {
            PersistentGlobalGameTracker.tracker.minigame1.selected = toggle.isOn;
        }

        if (this.gameObject.name.Contains("2"))
        {
            PersistentGlobalGameTracker.tracker.minigame2.selected = toggle.isOn;
        }
        if (this.gameObject.name.Contains("3"))
        {
            PersistentGlobalGameTracker.tracker.minigame3.selected = toggle.isOn;
        }
     
    }

    public bool HasTargetNumber(int targetNumber)
    {
        
        // Check if the GameObject's name contains the target number as a substring.
        return gameObject.name.Contains(targetNumber.ToString());
    }
}
