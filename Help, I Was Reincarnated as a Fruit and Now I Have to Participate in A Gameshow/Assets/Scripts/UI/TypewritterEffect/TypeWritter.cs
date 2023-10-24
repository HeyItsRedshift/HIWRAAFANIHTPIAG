using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public float typeSpeed = 0.05f;
    public float spedUpTypeSpeed = 0.01f;

    public List<string> textEntries;
    private int currentEntryIndex = 0;

    private bool isTyping = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isTyping)
        {
            if (currentEntryIndex < textEntries.Count)
            {
                StartCoroutine(ShowText(textEntries[currentEntryIndex]));
                currentEntryIndex++;
                if (currentEntryIndex >= textEntries.Count)
                {
                    currentEntryIndex = 0;
                }
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

            // Check if the ENTER key is currently being held down for sped up typing
            float currentSpeed = Input.GetKey(KeyCode.Return) ? spedUpTypeSpeed : typeSpeed;

            yield return new WaitForSeconds(currentSpeed);
        }

        isTyping = false;
    }
}
