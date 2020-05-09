using UnityEngine;

namespace TheGame.Map
{
    interface ICoridor
    {
        byte[,] CoridorMap { get; set; }
        Vector2Int Direction { get; set; }
        Vector2Int LeftTopPos { get; set; }
        void Init(Vector2Int position, Vector2Int direction);
    }
}

