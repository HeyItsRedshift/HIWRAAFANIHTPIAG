using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;




public class ArrowsForRounds : MonoBehaviour
{
    private float timerTarget = 0; // Adjust this value to control the rate of changes.
   [SerializeField] private GameObject roundsCounter;
    private float timerBetweenButtonPresses = 0 ; // Adjust this value to control the rate of changes.
    private float timerPressDelay = 0.3f;
    private int rounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        timerBetweenButtonPresses = timerBetweenButtonPresses - Time.deltaTime;
   

    }
    // Update is called once per frame
    void Update()
    {
        print(Input.GetAxis("Horizontal"));
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
                    DecreaseRounds();
                    timerTarget = Time.time + timerPressDelay;

                }
                else if (horizontalInput > 0)
                {
                    //play right button animation
                    IncreaseRounds();
                    timerTarget = Time.time + timerPressDelay;

                }


            }

        }


        /*
         * Old one might delete later -> using Time.time for more accurate timer results
         *
        if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.CompareTag("RoundsButton"))
        {
            float horizontalInputOut = Input.GetAxis("Horizontal");

            if (horizontalInputOut == 0 && timerBetweenButtonPresses>0) { timerBetweenButtonPresses = 0; }


            if (timerBetweenButtonPresses <= 0)
            {
                float horizontalInput = Input.GetAxis("Horizontal");

                if (horizontalInput < 0)
                {
                    DecreaseRounds();
                    timerBetweenButtonPresses = timerPressDelay;

                }
                else if (horizontalInput > 0)
                {
                    IncreaseRounds();
                    timerBetweenButtonPresses = timerPressDelay;

                }


            }
           
        } */
    }
    void IncreaseRounds()
    {
        rounds++;
        roundsCounter.GetComponent<TextMeshProUGUI>().text = rounds.ToString();
    }
    void DecreaseRounds()
    {
        rounds--;
        roundsCounter.GetComponent<TextMeshProUGUI>().text = rounds.ToString();


    }
}

