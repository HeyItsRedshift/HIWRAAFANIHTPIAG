using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Keys keyPrefab; // Assuming "Keys" is a MonoBehaviour script.

    [Header("Keyboard Lines")]
    [SerializeField] private KeyboardLine[] lines;

    [Header("Key Settings")]
    [Range(0f, 1)]
    [SerializeField] private float keyToLineRatio;
    [Range(0f, 1f)]
    [SerializeField] private float keyXSpacing;
    [Range(0f, 1f)]
    [SerializeField] private float keyYSpacingRatio = 0.1f;  // Defaults to 10% of keyWidth

    // Start is called before the first frame update
    void Start()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width / 3, Screen.height / 3);
        // Reducing the height of the keyboard by a certain ratio, e.g., by 20%
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y * 0.6f);

        CreateKeys();

    }

    // Update is called once per frame
    void Update()
    {
        PlaceKeys();
    }

    private void CreateKeys()
    {
        for (int i = 0; i < lines.Length; i++) // Fixed the typo here.
        {
            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                char keyChar = lines[i].keys[j];
                Keys keyInstance = Instantiate(keyPrefab, rectTransform); // Fixed the type here.
                keyInstance.SetKey(keyChar);
            }
        }
    }
    private void PlaceKeys()
    {
        int lineCount = lines.Length;
        // Calculate keyWidth first
        float keyWidth = rectTransform.rect.height * keyToLineRatio / lineCount;

        // Now, use keyWidth to compute lineHeight
        float keyHeight = keyWidth;  // If keys are not square, adjust this.
        float lineHeight = keyHeight + (keyWidth * keyYSpacingRatio);


        float xSpacing = keyXSpacing * keyWidth;  // changed to keyWidth for consistency


        int currentKeyIndex = 0;
        for (int i = 0; i < lineCount; i++)
        {
            float halfKeyCount = (float)lines[i].keys.Length / 2;
            float totalLineWidth = (keyWidth + xSpacing) * lines[i].keys.Length - xSpacing;  // subtract xSpacing to not count the space after the last key
            float startX = -totalLineWidth / 2 + keyWidth / 2;  // beginning from the leftmost key's center point

            float lineY = rectTransform.rect.height / 2 - (lineHeight / 2) - i * lineHeight;

            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                float keyX = startX + j * (keyWidth + xSpacing);

                Vector2 keyAnchoredPosition = new Vector2(keyX, lineY); // renamed to keyAnchoredPosition for clarity

                RectTransform keyRectTransform = rectTransform.GetChild(currentKeyIndex).GetComponent<RectTransform>();
                keyRectTransform.anchoredPosition = keyAnchoredPosition;  // using anchoredPosition here
                keyRectTransform.sizeDelta = new Vector2(keyWidth, keyWidth);

                currentKeyIndex++;
            }
        }
    }

}

[System.Serializable]
public struct KeyboardLine
{
    public string keys;
}
