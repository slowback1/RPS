﻿using System;

namespace RPS
{
    class Controller
    {
        readonly Model A;
        public Controller(Model m)
        {
            A = m;
        }
        public int ProcessResult(string uInput)
        {
            int uInt = ProcessValues(uInput);
            int oInt = A.SetOpposingRPS();
            A.UpdateInputHistory(uInt);
            int ResInt = CompareRPS(uInt, oInt);
            A.UpdateScores(ResInt);
            return ResInt;
        }
        public int ProcessValues(string uInput)
        {
            var uInt = uInput switch
            {
                "r" => 1,
                "p" => 2,
                "s" => 3,
                _ => throw new Exception(),
            };
            return uInt;
        }
        //1 == 'rock'
        //2 == 'paper'
        //3 == 'scissors'
        //so 1 < 2 < 3 < 1
        // for return value 0 is lose, 1 is win, 2 is tie
        public int CompareRPS(int uRPS, int oRPS)
        {
            switch (uRPS)
            {
                case 1:
                    if (oRPS == 2)
                    {
                        return 0;
                    }
                    else if (oRPS == 3)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                case 2:
                    if (oRPS == 1)
                    {
                        return 0;
                    }
                    else if (oRPS == 3)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }

                case 3:
                    if (oRPS == 1)
                    {
                        return 0;
                    }
                    else if (oRPS == 2)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                default:
                    throw new Exception();
            }
        }

    }
}
