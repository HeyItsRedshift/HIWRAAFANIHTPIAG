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
        int easyPoints = 5;
        int mediumPoints = 10;
        int hardPoints = 15;

        var easyWords = new Dictionary<string, string>
         {
            {"Apple", "Fruit"},
            {"Ball", "Sports"},
            {"Cat", "Animal"},
            {"Dog", "Animal"},
            {"Egg", "Food"},
            {"Fish", "Animal"},
            {"Goat", "Animal"},
            {"Hat", "Clothing"},
            {"Ice", "Nature"},
            {"Jam", "Food"},
            {"Kite", "Toy"},
            {"Lion", "Animal"},
            {"Moon", "Space"},
            {"Nest", "Nature"},
            {"Owl", "Animal"},
            {"Pig", "Animal"},
            {"Queen", "People"},
            {"Rose", "Flower"},
            {"Sun", "Space"},
            {"Tree", "Nature"},
            {"Umbrella", "Object"},
            {"Van", "Vehicle"},
            {"Watch", "Object"},
            {"Xylophone", "Musical Instrument"},
            {"Yarn", "Craft"},
            {"Zebra", "Animal"}
          };


        var mediumWords = new Dictionary<string, string>
        {
            {"Angel", "Mythical"},
            {"Boat", "Vehicle"},
            {"Car", "Vehicle"},
            {"Duck", "Animal"},
            {"Elephant", "Animal"},
            {"Flower", "Nature"},
            {"Grapes", "Fruit"},
            {"House", "Object"},
            {"Island", "Geography"},
            {"Jewel", "Object"},
            {"Kangaroo", "Animal"},
            {"Leaf", "Nature"},
            {"Mountain", "Geography"},
            {"Night", "Time"},
            {"Orange", "Fruit"},
            {"Piano", "Musical Instrument"},
            {"Quilt", "Craft"},
            {"Rainbow", "Nature"},
            {"Snow", "Nature"},
            {"Tiger", "Animal"},
            {"Unicorn", "Mythical"},
            {"Violin", "Musical Instrument"},
            {"Whale", "Animal"},
            {"X-ray", "Science"},
            {"Yo-yo", "Toy"}
        };


        var hardWords = new Dictionary<string, string>
        {
            {"Acorn", "Nature"},
            {"Banana", "Fruit"},
            {"Cherry", "Fruit"},
            {"Date", "Fruit"},
            {"Eclipse", "Space"},
            {"Fjord", "Geography"},
            {"Glacier", "Nature"},
            {"Harbor", "Geography"},
            {"Island", "Geography"},
            {"Lagoon", "Geography"},
            {"Marsh", "Nature"},
            {"Oasis", "Geography"},
            {"Peak", "Geography"},
            {"Quarry", "Geography"},
            {"Reef", "Nature"},
            {"Shore", "Geography"},
            {"Tundra", "Geography"},
            {"Volcano", "Geography"},
            {"Wetland", "Nature"},
            {"X-ray", "Science"},
            {"Bay", "Geography"},
            {"Canyon", "Geography"},
            {"Delta", "Geography"},
            {"Forest", "Nature"},
            {"Garden", "Nature"}
        };



        // Adding easy words
        foreach (var word in easyWords)
        {
            words.Add(new GameWord(word.Key, easyPoints, word.Value, "Easy"));
        }

        // Adding medium words
        foreach (var word in mediumWords)
        {
            words.Add(new GameWord(word.Key, mediumPoints, word.Value, "Medium"));
        }

        // Adding hard words
        foreach (var word in hardWords)
        {
            words.Add(new GameWord(word.Key, hardPoints, word.Value, "Hard"));
        }

        // Fill the list for random selection
        wordsList.AddRange(words);
    }

    // Continuation from Part 1...

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
}

