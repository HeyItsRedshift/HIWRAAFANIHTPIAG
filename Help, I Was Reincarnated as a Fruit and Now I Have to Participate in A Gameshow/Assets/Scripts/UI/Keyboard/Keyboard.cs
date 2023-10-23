using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Keys keyPrefab;

    [Header("Keyboard Lines")]
    [SerializeField] private KeyboardLine[] lines;

    [Header("Key Settings")]
    [Range(0f, 1)]
    [SerializeField] private float keyToLineRatio;
    [Range(0f, 1f)]
    [SerializeField] private float keyXSpacing;
    [Range(0f, 1f)]
    [SerializeField] private float keyYSpacingRatio = 0.1f;
    [Range(0f,1f)]
    [SerializeField] private float keyboardWidth;
    [Range(0f, 1f)]
    [SerializeField] private float keyboardHeight;
    [Header("Margin Settings")]
    [Range(0f, 0.5f)]
    [SerializeField] private float topMargin = 0.1f;     // Defaults to 10% of keyboard height
    [Range(0f, 0.5f)]
    [SerializeField] private float bottomMargin = 0.1f;  // Defaults to 10% of keyboard height
    [Range(0f, 0.5f)]
    [SerializeField] private float leftMargin = 0.1f;    // Defaults to 10% of keyboard width
    [Range(0f, 0.5f)]
    [SerializeField] private float rightMargin = 0.1f;   // Defaults to 10% of keyboard width

    void Start()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width / (1 / keyboardWidth), Screen.height / (1/keyboardHeight));
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y * 0.6f);

        CreateKeys();
    }

    void Update()
    {
        PlaceKeys();
        rectTransform.sizeDelta = new Vector2(Screen.width / (1 / keyboardWidth), Screen.height / (1 / keyboardHeight));
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y * 0.6f);
    }

    private void CreateKeys()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                string keyStr = lines[i].keys[j];
                Keys keyInstance = Instantiate(keyPrefab, rectTransform);
                keyInstance.SetKey(keyStr);
            }
        }
    }

    private void PlaceKeys()
    {
        int lineCount = lines.Length;

        float availableHeight = rectTransform.rect.height * (1 - topMargin - bottomMargin);
        float availableWidth = rectTransform.rect.width * (1 - leftMargin - rightMargin);

        float keyWidth = availableHeight * keyToLineRatio / lineCount;
        float keyHeight = keyWidth;
        float lineHeight = keyHeight + (keyWidth * keyYSpacingRatio);
        float xSpacing = keyXSpacing * keyWidth;

        int currentKeyIndex = 0;
        for (int i = 0; i < lineCount; i++)
        {
            float halfKeyCount = (float)lines[i].keys.Length / 2;
            float totalLineWidth = (keyWidth + xSpacing) * lines[i].keys.Length - xSpacing;
            float startX = -totalLineWidth / 2 + keyWidth / 2 + (rectTransform.rect.width - availableWidth) / 2;
            float lineY = rectTransform.rect.height * (1 - topMargin) / 2 - (lineHeight / 2) - i * lineHeight;

            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                float keyX = startX + j * (keyWidth + xSpacing);

                Vector2 keyAnchoredPosition = new Vector2(keyX, lineY);
                RectTransform keyRectTransform = rectTransform.GetChild(currentKeyIndex).GetComponent<RectTransform>();
                keyRectTransform.anchoredPosition = keyAnchoredPosition;
                keyRectTransform.sizeDelta = new Vector2(keyWidth, keyHeight);

                currentKeyIndex++;
            }
        }
    }
   }


    [System.Serializable]
public struct KeyboardLine
{
    public string[] keys;
}
