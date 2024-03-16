using Snake.Models;
using Snake.Services.Interfaces;

namespace Snake.Services
{
    public class ScoreService : IScoreService
    {
        private int score;
        private int level;
        private int increaseScoreIndex;
        private int increaseFrames;

        public ScoreService()
        {
            level = 1;
            increaseScoreIndex = 1;
            increaseFrames = 1;
        }

        public int Score => score;

        public int Level => level;


        public void IncreaseScore(ISnakeService snakeService)
        {
            var isLevelIncrease = IncreaseLevel(snakeService.Body);

            if (isLevelIncrease)
            {
                snakeService.IncreaseSpeed(increaseFrames);
            }
            else
            {
                snakeService.IncreaseSpeed(1);
            }

            score += increaseScoreIndex * Level;
        }

        private bool IncreaseLevel(IEnumerable<Coordinates> snakeBody)
        {
            if (snakeBody.Count() % 10 == 0)
            {
                level++;

                if (level % 5 == 0)
                {
                    increaseScoreIndex++;
                }

                increaseFrames++;
                return true;
            }

            return false;
        }
    }
}
