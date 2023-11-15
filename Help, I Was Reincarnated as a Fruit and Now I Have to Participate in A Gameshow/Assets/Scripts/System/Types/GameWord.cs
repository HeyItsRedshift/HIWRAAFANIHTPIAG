using System;
using System.Collections.Generic;
using TMPro;

public class GameWord
{
    public string Word { get; private set; }
    public int Points { get; private set; }
    public string Id { get; private set; }
    public string Category { get; private set; }
    public string Difficulty { get; private set; }

    public GameWord(string word, int points, string category, string difficulty)
    {
        Word = word;
        Points = points;
        Id = Guid.NewGuid().ToString();
        Category = category;
        Difficulty = difficulty;
    }
}

public class WordGuessingGame
{
    private HashSet<GameWord> words;
    private List<GameWord> wordsList; // Used for random selection

    public WordGuessingGame()
    {
        words = new HashSet<GameWord>();
        wordsList = new List<GameWord>();
        InitializeWords();
    }

    private void InitializeWords()
    {
        // Easy words are generally more common and simpler
        string[] easyWords = { "Apple", "Ball", "Cat", "Dog", "Egg", "Fish", "Goat", "Hat", "Ice", "Jam", "Kite", "Lion", "Moon", "Nest", "Owl", "Pig", "Queen", "Rose", "Sun", "Tree", "Umbrella", "Van", "Watch", "Yarn", "Zebra" };

        // Medium words might be less common or slightly more complex
        string[] mediumWords = { "Angel", "Boat", "Car", "Duck", "Elephant", "Flower", "Grapes", "House", "Island", "Jewel", "Kangaroo", "Leaf", "Mountain", "Night", "Orange", "Piano", "Quilt", "Rainbow", "Snow", "Tiger", "Unicorn", "Violin", "Whale", "Xylophone", "Yo-yo" };

        // Hard words might be complex, less common or abstract concepts
        string[] hardWords = { "Acorn", "Banana", "Cherry", "Date", "Eclipse", "Fjord", "Glacier", "Harbor", "Island", "Lagoon", "Marsh", "Oasis", "Peak", "Quarry", "Reef", "Shore", "Tundra", "Volcano", "Wetland", "X-ray", "Bay", "Canyon", "Delta", "Forest", "Garden" };

        // Adding easy words
        foreach (var word in easyWords)
        {
            words.Add(new GameWord(word, 5, "Category", "Easy"));
        }
        // Adding medium words
        foreach (var word in mediumWords)
        {
            words.Add(new GameWord(word, 10, "Category", "Medium"));
        }
        // Adding hard words
        foreach (var word in hardWords)
        {
            words.Add(new GameWord(word, 15, "Category", "Hard"));
        }

        // Fill the list for random selection
        wordsList.AddRange(words);
    }

    public GameWord ChooseRandomWord()
    {
        if (wordsList.Count == 0)
        {
            // Refill the list if empty
            wordsList.AddRange(words);
        }

        Random rnd = new Random();
        int index = rnd.Next(wordsList.Count);
        GameWord selectedWord = wordsList[index];
        wordsList.RemoveAt(index); // Remove the selected word to avoid immediate repetition

        return selectedWord;
    }


    // Method to add a new word
    public void AddWord(string word, int points, string category, string difficulty)
    {
        var newWord = new GameWord(word, points, category, difficulty);
        if (words.Add(newWord))
        {
            wordsList.Add(newWord); // Add the new word to the list if it's not a duplicate
        }
    }

    // Additional methods as needed for your game logic

    // Example usage in your game:
    // var game = new WordGuessingGame();
    // var easyWord = game.ChooseRandomWord("Easy");
    // var mediumWord = game.ChooseRandomWord("Medium");
    // var hardWord = game.ChooseRandomWord("Hard");

}
