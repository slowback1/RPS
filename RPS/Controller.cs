using System;

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
                    return oRPS switch
                    {
                        2 => 0,
                        3 => 1,
                        _ => 2
                    };
                case 2:
                    return oRPS switch
                    {
                        1 => 0,
                        3 => 1,
                        _ => 2
                    };
                case 3:
                    return oRPS switch
                    {
                        1 => 0,
                        2 => 1,
                        _ => 2
                    };
                default:
                    throw new Exception();
            }
        }

    }
}
