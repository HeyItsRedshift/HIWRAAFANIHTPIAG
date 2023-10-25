using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Keyboard : MonoBehaviour

{
    [Header("Where u")]
    [SerializeField] Vector3 keyScale = new Vector3(0.5f, 0.5f, 1);
    [Header("Elements")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Keys keyPrefab;

    [Header("Keyboard Lines")]
    [SerializeField] private KeyboardLine[] lines;

    [Header("Key Settings")]
    [Range(0f, 1f)]
    [SerializeField] private float keyToLineRatio;
    [Range(-2f, 1f)]
    [SerializeField] private float keyXSpacing;
    [Range(-2f, 1f)]
    [SerializeField] private float keyYSpacingRatio = 0.1f;

    [Header("Keyboard Dimensions")]
    [SerializeField] private float keyboardWidth = 500f;
    [SerializeField] private float keyboardHeight = 300f;

    private List<Keys> allKeys = new List<Keys>();
    
    void Start()
    {
        CreateKeys();
        PlaceKeys();


    }

    void Update()
    {

        rectTransform.sizeDelta = new Vector2(keyboardWidth, keyboardHeight);

    }

    private void CreateKeys()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                string keyString = lines[i].keys[j];
                Keys keyInstance = Instantiate(keyPrefab, rectTransform);
                keyInstance.transform.localScale = keyScale;
                keyInstance.SetKey(keyString);

                if (keyString == "CAPS")
                {
                    keyInstance.GetButton().onClick.AddListener(OnCapsPressed);
                }

                allKeys.Add(keyInstance);
            }
        }
    }

    private void PlaceKeys()
    {
        int lineCount = lines.Length;
        float keyWidth = keyboardHeight * keyToLineRatio / (lineCount + 1);  // Added +1 for top margin
        float keyHeight = keyWidth;
        float lineHeight = keyHeight + (keyWidth * keyYSpacingRatio);
        float xSpacing = keyXSpacing * keyWidth;

        int currentKeyIndex = 0;
        for (int i = 0; i < lineCount; i++)
        {
            float totalLineWidth = 0;

            for (int k = 0; k < lines[i].keys.Length; k++)
            {
                float thisKeyWidth = keyWidth;
                if (lines[i].keys[k] == "_") thisKeyWidth *= 2;
                else if (lines[i].keys[k] == "<-") thisKeyWidth *= 1.5f;

                totalLineWidth += thisKeyWidth + xSpacing;
            }

            totalLineWidth -= xSpacing;
            float startX = -totalLineWidth / 2;

            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                float thisKeyWidth = keyWidth;

                if (lines[i].keys[j] == "_")
                    thisKeyWidth *= 2;
                else if (lines[i].keys[j] == "<-")
                    thisKeyWidth *= 1f;

                float keyX = startX + (thisKeyWidth / 2);
                startX += thisKeyWidth + xSpacing;

                float lineY = (keyboardHeight / 2) - (lineHeight * (i + 1));  // Adjusted for top margin

                RectTransform keyRectTransform = allKeys[currentKeyIndex].GetComponent<RectTransform>();
                keyRectTransform.anchoredPosition = new Vector2(keyX, lineY);
                keyRectTransform.sizeDelta = new Vector2(thisKeyWidth, keyWidth);

                currentKeyIndex++;
            }
        }
    }

    private void OnCapsPressed()
    {
        foreach (var key in allKeys)
        {
            key.ToggleCaps();
        }
    }
}

[System.Serializable]
public struct KeyboardLine
{
    public string[] keys;
}
