using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCardFlipAnimation : MonoBehaviour
{
    bool timerSet = false;
    bool animationTriggered = false;

    float timerCounter = 0;
    public float delay;
    public float timerDelay;
    public bool timeToSpawn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeToSpawn) { TriggerTimerAndAnimation(); }
    }

    public void TriggerTimerAndAnimation()
    {

        if (!timerSet) { timerCounter = Time.time + timerDelay; timerSet = true; }
        if (Time.time >= timerCounter) {
            if (!animationTriggered)
            {
                this.gameObject.GetComponent<Animator>().SetTrigger("Flip"); animationTriggered = true;
            }
        }

    }

}
