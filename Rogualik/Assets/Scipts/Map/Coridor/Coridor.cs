using System;
using UnityEngine;

namespace TheGame.Map
{
    class Coridor : ICoridor
    {
        public byte[,] CoridorMap { get; set; }
        public Vector2Int Direction { get; set; }
        public Vector2Int LeftTopPos { get; set; }

        public void Init(Vector2Int position, Vector2Int direction)
        {
            LeftTopPos = position;
            Direction = direction;

            var sizeX = 2 + Math.Abs(1 * direction.x);
            var sizeY = 2 + Math.Abs(1 * direction.y);

            CoridorMap = new byte[sizeY, sizeX];

            if (sizeX == 3)
                for (int i = 0; i < 2; i++)
                {
                    CoridorMap[i, 0] = 1;
                    CoridorMap[i, 2] = 1;
                }
            else if (sizeY == 3)
                for (int i = 0; i < 2; i++)
                {
                    CoridorMap[0, i] = 1;
                    CoridorMap[2, i] = 1;
                }
        }
    }
}
