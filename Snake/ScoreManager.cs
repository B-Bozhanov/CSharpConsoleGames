namespace Snake
{
    public class ScoreManager
    {
        private int score;
        private int level;
        private int increaseScoreIndex;
        private int increaseFrames;

        public ScoreManager()
        {
            this.level = 1;
            this.increaseScoreIndex = 1;
            this.increaseFrames = 1;
        }

        public int Score => this.score;

        public int Level => this.level;


        public void IncreaseScore(Snake snake)
        {
            var isLevelIncrease = this.IncreaseLevel(snake.Body);

            if (isLevelIncrease)
            {
                snake.IncreaseSpeed(this.increaseFrames);
            }
            else
            {
                snake.IncreaseSpeed(1);
            }

            this.score += this.increaseScoreIndex * Level;
        }

        private bool IncreaseLevel(IEnumerable<Coordinates> snakeBody)
        {
            if (snakeBody.Count() % 10 == 0)
            {
                this.level++;

                if (this.level % 5 == 0)
                {
                    this.increaseScoreIndex++;
                }

                this.increaseFrames++;
                return true;
            }

            return false;
        }
    }
}
