using UnityEngine;

namespace TheGame
{
    public interface IWorld
    {
        int Size { get; set; }
        byte[,] Map { get; set; }
        void Init();
        void CreateRoom(Vector2Int prevRoomCoord, Vector2Int direction);
    }

}
