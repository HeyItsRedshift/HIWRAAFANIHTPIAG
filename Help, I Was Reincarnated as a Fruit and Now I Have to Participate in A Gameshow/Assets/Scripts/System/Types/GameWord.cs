
    [System.Serializable] // This attribute allows the class to be serialized by Unity.
    public class GameWord
    {
        public string word;
        public int points;

        public GameWord(string word, int points)
        {
            this.word = word;
            this.points = points;
        }
    }
