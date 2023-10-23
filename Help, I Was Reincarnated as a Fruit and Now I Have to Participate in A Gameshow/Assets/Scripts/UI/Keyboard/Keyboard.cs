using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keyboard : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Keys keyPrefab;

    [Header("Keyboard Lines")]
    [SerializeField] private KeyboardLine[] lines;

    [Header("Key Settings")]
    [Range(0f, 1f)]
    [SerializeField] private float keyToLineRatio;
    [Range(0f, 1f)]
    [SerializeField] private float keyXSpacing;
    [Range(0f, 1f)]
    [SerializeField] private float keyYSpacingRatio = 0.1f;

    [Header("Keyboard Margins")]
    [SerializeField] private float topMargin;
    [SerializeField] private float leftMargin;
    [SerializeField] private float bottomMargin;

    private List<Keys> allKeys = new List<Keys>();

    void Start()
    {
        CreateKeys();
        PlaceKeys();
    }

    private void CreateKeys()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                string keyString = lines[i].keys[j];
                Keys keyInstance = Instantiate(keyPrefab, rectTransform);
                keyInstance.SetKey(keyString);
                allKeys.Add(keyInstance);
            }
        }
    }

    private void PlaceKeys()
    {
        int lineCount = lines.Length;
        float keyWidth = (rectTransform.rect.width - leftMargin) * keyToLineRatio / lineCount;
        float keyHeight = keyWidth;
        float lineHeight = keyHeight + (keyWidth * keyYSpacingRatio);
        float xSpacing = keyXSpacing * keyWidth;

        int currentKeyIndex = 0;
        for (int i = 0; i < lineCount; i++)
        {
            float halfKeyCount = (float)lines[i].keys.Length / 2;
            float totalLineWidth = (keyWidth + xSpacing) * lines[i].keys.Length - xSpacing;
            float startX = -totalLineWidth / 2 + keyWidth / 2 + leftMargin;
            float lineY = rectTransform.rect.height / 2 - topMargin - (lineHeight / 2) - i * lineHeight;

            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                float keyX = startX + j * (keyWidth + xSpacing);
                Vector2 keyAnchoredPosition = new Vector2(keyX, lineY);
                RectTransform keyRectTransform = allKeys[currentKeyIndex].GetComponent<RectTransform>();
                keyRectTransform.anchoredPosition = keyAnchoredPosition;
                keyRectTransform.sizeDelta = new Vector2(keyWidth, keyWidth);
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
