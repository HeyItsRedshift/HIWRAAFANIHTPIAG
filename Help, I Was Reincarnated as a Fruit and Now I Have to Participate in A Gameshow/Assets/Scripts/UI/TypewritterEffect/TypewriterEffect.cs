using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; // For Action

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public float typeSpeed = 0.05f;
    public float spedUpTypeSpeed = 0.01f;
    public bool typeWriterFinished = false;
    public List<string> textEntries;
    private int currentEntryIndex = 0;
    private bool firstTime = true;
    private bool isTyping = false;

    public event Action OnAllEntriesCompleted; // Event to signal completion of all entries

    private void Update()
    {
        if (firstTime)
        {
            if (!isTyping)
            {
                firstTime = false;
                if (currentEntryIndex < textEntries.Count)
                {
                    StartCoroutine(ShowText(textEntries[currentEntryIndex]));
                    currentEntryIndex++;

                }
                else
                {
                    // All entries have been shown, trigger the event
                    OnAllEntriesCompleted?.Invoke();
                    currentEntryIndex = 0; // Reset index if you need to show entries again later
                    typeWriterFinished = true;
                    Destroy(this.gameObject);
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.Return) && !isTyping)
        {
            if (currentEntryIndex < textEntries.Count)
            {
                StartCoroutine(ShowText(textEntries[currentEntryIndex]));
                currentEntryIndex++;
            }
            else
            {
                // All entries have been shown, trigger the event
                OnAllEntriesCompleted?.Invoke();
                currentEntryIndex = 0; // Reset index if you need to show entries again later
                typeWriterFinished = true;
                Destroy(this.gameObject);
            }
        }
    }
  
        public IEnumerator ShowText(string text)
        {
            isTyping = true;
            uiText.text = "";

            foreach (char c in text)
            {
                uiText.text += c;
                float currentSpeed = Input.GetKey(KeyCode.Return) ? spedUpTypeSpeed : typeSpeed;
                yield return new WaitForSeconds(currentSpeed);
            }

            isTyping = false;
        }
       

   
}