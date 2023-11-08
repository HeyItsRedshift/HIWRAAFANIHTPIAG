using System.Collections.Generic;
using UnityEngine;

public class GameDictionary : MonoBehaviour
{
    [SerializeField] // This attribute makes the list show up in the Inspector.
    private List<GameWord> words = new List<GameWord>();

    // This method adds a new word with points to the list.
    public void AddWord(string word, int points)
    {
        words.Add(new GameWord(word, points));
    }

    // This method attempts to remove a word from the list.
    public bool RemoveWord(string word)
    {
        return words.RemoveAll(w => w.word == word) > 0;
    }

    // Call this method to debug the current list of words.
    public void DebugWords()
    {
        foreach (var gameWord in words)
        {
            Debug.Log($"Word: {gameWord.word}, Points: {gameWord.points}");
        }
    }
}
