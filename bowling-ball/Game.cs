﻿using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        private List<int> rolls =new List<int>();

        public void Roll(int pins)
        {
            rolls.Add(pins);
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike(frameIndex))
                {
                    score += 10 + strikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (isSpare(frameIndex))
                {
                    score += 10 + spareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += sumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }
        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private int sumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int spareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int strikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

    }
}

