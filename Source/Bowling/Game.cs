using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class Game
    {
        private int _score;
        private int _frameCount;
        private bool _isFirstRoll;
        private int _bonusRoll;

        private int[,] frames = new int[10,2];

        public Game()
        {
            _score = 0;
            _frameCount = 0;
            _isFirstRoll = true;
        }

        private int previousFrame
        {
            get { return _frameCount - 1; }
        }

        private bool lastFrame()
        {
            return _frameCount == 9;
        }

        public bool CanBowl()
        {
            return _frameCount < 10 ? true : false;
        }

        public void Roll(int _pins)
        {
            if (CanBowl())
            {
                int _rollScore = _pins;

                if (_isFirstRoll )
                {
                    
                    if (_frameCount != 0)
                    {
                        if (IsStrike(frames[(previousFrame), 0], _isFirstRoll)) //_isFirstRoll slightly redundant here
                        {
                            frames[(previousFrame), 1] += (_rollScore);
                        }
                        else if (IsSpare(frames[(previousFrame), 0], frames[(previousFrame), 1]))
                        {
                            frames[(previousFrame), 1] += _rollScore;
                        }
                    }
                    if (_frameCount > 1 && IsStrike(frames[(previousFrame), 0], _isFirstRoll) && IsStrike(frames[(previousFrame - 1), 0], _isFirstRoll)) 
                        frames[(previousFrame - 1), 1] += (_rollScore); //2nd strike bonus

                    if (IsStrike(_rollScore, _isFirstRoll)) if (!lastFrame()) _frameCount++;
                    
                }
                else if (!lastFrame())
                {
                    if (_frameCount != 0 && IsStrike(frames[(previousFrame), 0], true)) frames[(previousFrame), 1] += (_rollScore); //2nd strike bonus

                    _frameCount++;
                }
                else if (lastFrameContinue(frames[(_frameCount), 0],_rollScore))  //10th frame is special
                {

                }

                int currentFrame = (IsStrike(_rollScore, _isFirstRoll) || !_isFirstRoll) && !lastFrame() ? previousFrame : _frameCount; // because of OoO, need to shift the count if strike or 2nd roll 

                frames[currentFrame, Convert.ToInt32(!_isFirstRoll)] = _rollScore; //flip the bit

                _isFirstRoll = IsStrike(_rollScore, _isFirstRoll) ? true && !lastFrame() : !_isFirstRoll;
            }
        }

        private bool IsSpare(int firstRoll, int secondRoll)
        {
            return firstRoll + secondRoll == 10;
        }

        private bool IsStrike(int rollScore, bool isFirst) //need both values for reuse
        {
            return (rollScore == 10 && isFirst);
            
        }

        private bool lastFrameContinue(int firstRoll, int secondRoll)
        {
            var _continue = lastFrame();
            _continue = firstRoll == 10;
            if(!_continue) _continue = secondRoll != 10 ? IsSpare(firstRoll, secondRoll) : true;

            return _continue;
        }

        public int Score()
        {
            for (int i = 0; i < _frameCount; i++)
            {

                _score += (frames[(i), 0] + frames[(i), 1]);
            }
            return _score;
        }
    }
}
