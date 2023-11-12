using System;
using System.Collections.Generic;
using TMPro;
public class GameWord
{
    public string Word { get; private set; }
    public int Points { get; private set; }
    public string Id { get; private set; }
    public string Category { get; private set; }

    public GameWord(string word, int points, string category)
    {
        Word = word;
        Points = points;
        Id = Guid.NewGuid().ToString(); // Generates a unique identifier
        Category = category;
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
        words.Add(new GameWord("Apple", 5, "Fruit"));
        words.Add(new GameWord("Ball", 5, "Sports"));
        words.Add(new GameWord("Cat", 5, "Animal"));
        words.Add(new GameWord("Dog", 5, "Animal"));
        words.Add(new GameWord("Egg", 5, "Food"));
        words.Add(new GameWord("Fish", 5, "Animal"));
        words.Add(new GameWord("Goat", 5, "Animal"));
        words.Add(new GameWord("Hat", 5, "Clothing"));
        words.Add(new GameWord("Ice", 5, "Nature"));
        words.Add(new GameWord("Jam", 5, "Food"));
        words.Add(new GameWord("Kite", 5, "Toy"));
        words.Add(new GameWord("Lion", 5, "Animal"));
        words.Add(new GameWord("Moon", 5, "Space"));
        words.Add(new GameWord("Nest", 5, "Nature"));
        words.Add(new GameWord("Owl", 5, "Animal"));
        words.Add(new GameWord("Pig", 5, "Animal"));
        words.Add(new GameWord("Queen", 5, "People"));
        words.Add(new GameWord("Rose", 5, "Flower"));
        words.Add(new GameWord("Sun", 5, "Space"));
        words.Add(new GameWord("Tree", 5, "Nature"));
        words.Add(new GameWord("Umbrella", 5, "Object"));
        words.Add(new GameWord("Van", 5, "Vehicle"));
        words.Add(new GameWord("Watch", 5, "Object"));
        words.Add(new GameWord("Xylophone", 5, "Musical Instrument"));
        words.Add(new GameWord("Yarn", 5, "Craft"));
        words.Add(new GameWord("Zebra", 5, "Animal"));
        words.Add(new GameWord("Angel", 5, "Mythical"));
        words.Add(new GameWord("Boat", 5, "Vehicle"));
        words.Add(new GameWord("Car", 5, "Vehicle"));
        words.Add(new GameWord("Duck", 5, "Animal"));
        words.Add(new GameWord("Elephant", 5, "Animal"));
        words.Add(new GameWord("Flower", 5, "Nature"));
        words.Add(new GameWord("Grapes", 5, "Fruit"));
        words.Add(new GameWord("House", 5, "Object"));
        words.Add(new GameWord("Island", 5, "Geography"));
        words.Add(new GameWord("Jewel", 5, "Object"));
        words.Add(new GameWord("Kangaroo", 5, "Animal"));
        words.Add(new GameWord("Leaf", 5, "Nature"));
        words.Add(new GameWord("Mountain", 5, "Geography"));
        words.Add(new GameWord("Night", 5, "Time"));
        words.Add(new GameWord("Orange", 5, "Fruit"));
        words.Add(new GameWord("Piano", 5, "Musical Instrument"));
        words.Add(new GameWord("Quilt", 5, "Craft"));
        words.Add(new GameWord("Rainbow", 5, "Nature"));
        words.Add(new GameWord("Snow", 5, "Nature"));
        words.Add(new GameWord("Tiger", 5, "Animal"));
        words.Add(new GameWord("Unicorn", 5, "Mythical"));
        words.Add(new GameWord("Violin", 5, "Musical Instrument"));
        words.Add(new GameWord("Whale", 5, "Animal"));
        words.Add(new GameWord("X-ray", 5, "Science"));
        words.Add(new GameWord("Yo-yo", 5, "Toy"));
        words.Add(new GameWord("Zipper", 5, "Object"));
        words.Add(new GameWord("Beach", 5, "Geography"));
        words.Add(new GameWord("Cloud", 5, "Nature"));
        words.Add(new GameWord("Desert", 5, "Geography"));
        words.Add(new GameWord("Earth", 5, "Space"));
        words.Add(new GameWord("Forest", 5, "Nature"));
        words.Add(new GameWord("Garden", 5, "Nature"));
        words.Add(new GameWord("Hill", 5, "Geography"));
        words.Add(new GameWord("Iceberg", 5, "Nature"));
        words.Add(new GameWord("Jungle", 5, "Nature"));
        words.Add(new GameWord("Lake", 5, "Nature"));
        words.Add(new GameWord("Meadow", 5, "Nature"));
        words.Add(new GameWord("North", 5, "Direction"));
        words.Add(new GameWord("Ocean", 5, "Geography"));
        words.Add(new GameWord("Prairie", 5, "Nature"));
        words.Add(new GameWord("River", 5, "Nature"));
        words.Add(new GameWord("Stream", 5, "Nature"));
        words.Add(new GameWord("Valley", 5, "Geography"));
        words.Add(new GameWord("Waterfall", 5, "Nature"));
        words.Add(new GameWord("Bay", 5, "Geography"));
        words.Add(new GameWord("Canyon", 5, "Geography"));
        words.Add(new GameWord("Delta", 5, "Geography"));
        words.Add(new GameWord("Eclipse", 5, "Space"));
        words.Add(new GameWord("Fjord", 5, "Geography"));
        words.Add(new GameWord("Glacier", 5, "Nature"));
        words.Add(new GameWord("Harbor", 5, "Geography"));
        words.Add(new GameWord("Island", 5, "Geography"));
        words.Add(new GameWord("Lagoon", 5, "Geography"));
        words.Add(new GameWord("Marsh", 5, "Nature"));
        words.Add(new GameWord("Oasis", 5, "Geography"));
        words.Add(new GameWord("Peak", 5, "Geography"));
        words.Add(new GameWord("Quarry", 5, "Geography"));
        words.Add(new GameWord("Reef", 5, "Nature"));
        words.Add(new GameWord("Shore", 5, "Geography"));
        words.Add(new GameWord("Tundra", 5, "Geography"));
        words.Add(new GameWord("Volcano", 5, "Geography"));
        words.Add(new GameWord("Wetland", 5, "Nature"));
        words.Add(new GameWord("Airplane", 5, "Vehicle"));
        words.Add(new GameWord("Bicycle", 5, "Vehicle"));
        words.Add(new GameWord("Car", 5, "Vehicle"));
        words.Add(new GameWord("Train", 5, "Vehicle"));
        words.Add(new GameWord("Truck", 5, "Vehicle"));
        words.Add(new GameWord("Van", 5, "Vehicle"));
        words.Add(new GameWord("Yacht", 5, "Vehicle"));
        words.Add(new GameWord("Zeppelin", 5, "Vehicle"));
        words.Add(new GameWord("Acorn", 5, "Nature"));
        words.Add(new GameWord("Banana", 5, "Fruit"));
        words.Add(new GameWord("Cherry", 5, "Fruit"));
        words.Add(new GameWord("Date", 5, "Fruit"));
    }
    public GameWord ChooseRandomWord()
    {
        if (wordsList.Count == 0)
        {
            wordsList.AddRange(words); // Refill the list if empty
        }

        Random rnd = new Random();
        int index = rnd.Next(wordsList.Count);
        GameWord selectedWord = wordsList[index];
        wordsList.RemoveAt(index); // Remove the selected word to avoid repetition
        return selectedWord;
    }

    // Method to add a new word
    public void AddWord(string word, int points, string category)
    {
        words.Add(new GameWord(word, points, category));
    }

    // Additional methods as needed for your game logic
}
