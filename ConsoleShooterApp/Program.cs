using System;

namespace ConsoleShooterApp
{
    
    class Program
    {
        private const int ScreenWidht = 100;
        private const int ScreenHeight = 50;

        private const int MapWidth = 30;
        private const int MapHeigth = 30;

        private const double Fov = Math.PI / 3;

        private const double Depth = 16;

        private static double _playerX = 0;
        private static double _playerY = 0;
        private static double _playerAngle = 0;

        private static string _map = "";

        public static readonly char[] screen = new char[ScreenWidht * ScreenHeight];

        static void Main(string[] args)
        {
            Console.SetWindowSize(ScreenWidht, ScreenHeight);
            Console.SetBufferSize(ScreenWidht, ScreenHeight);
            Console.CursorVisible = false;

            _map += "##############################";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "#............................#";
            _map += "##############################";

            while (true)
            {
                for (int x = 0; x < ScreenWidht; x++)
                {
                    double rayAngle = _playerAngle + (Fov / 2) + (x * Fov / ScreenWidht);

                    double rayX = Math.Sin(rayAngle);
                    double rayY = Math.Cos(rayAngle);

                    double distanceToWall = 0;
                    bool hitWall = false;

                    while (!hitWall && distanceToWall < Depth)
                    {
                        distanceToWall += 0.1;

                        int testX = (int)(_playerX + rayX * distanceToWall);
                        int testY = (int)(_playerY + rayY * distanceToWall);

                        if (testX < 0 || testX >= _playerX + Depth || testY < 0 || testY >= _playerY + Depth)
                        {
                            hitWall = true;
                            distanceToWall = Depth;
                        }
                        else
                        {
                            char testCell = _map[testY + MapWidth + testX];

                            if (testCell == '#')
                            {
                                hitWall = true;
                            }
                        }

                    }

                }




                Console.SetCursorPosition(left:0, top:0);
                Console.Write(buffer: screen);

            }
        }
    }
}
