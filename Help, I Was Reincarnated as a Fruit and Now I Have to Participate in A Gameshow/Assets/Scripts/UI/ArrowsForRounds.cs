using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;




public class ArrowsForRounds : MonoBehaviour
{
    
    public Button leftArrow;
    public Button rightArrow;
    private float timerTarget = 0;
   [SerializeField] private GameObject roundsCounter;
    private float timerPressDelay = 0.3f; //This controls how many times you can add or remove a round per second
    private int rounds =1;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
   

    }
    // Update is called once per frame
    void Update()
    {
        rounds++;
        if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.CompareTag("RoundsButton"))
        {
            float horizontalInputOut = Input.GetAxis("Horizontal");

            if (horizontalInputOut == 0) { timerTarget = Time.time; }

            if (timerTarget <= Time.time)
            {
                float horizontalInput = Input.GetAxis("Horizontal");

                if (horizontalInput < 0)
                {
                    //play left button animation
                    leftArrow.onClick.Invoke();
                    leftArrow.gameObject.GetComponent<Animator>().SetTrigger("triggerMeTimbers");


                    //  DecreaseRounds();
                    timerTarget = Time.time + timerPressDelay;

                }
                else if (horizontalInput > 0)
                {
                    rightArrow.gameObject.GetComponent<Animator>().SetTrigger("triggerMeTimbers");

                    //play right button animation
                    rightArrow.onClick.Invoke();
                   // IncreaseRounds();
                    timerTarget = Time.time + timerPressDelay;

                }


            }

        }


    }
    public void IncreaseRounds()
    {

       PersistentGlobalGameTracker.tracker.IncreaseRounds();

    }
    public void DecreaseRounds()
    {

        PersistentGlobalGameTracker.tracker.DecreaseRounds();

    }
 
       
   
}

