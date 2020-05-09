using System.Collections.Generic;
using UnityEngine;

namespace TheGame.Map
{
    interface IRoom
    {
        byte[,] RoomMap { get; set; }

        List<IDoor> Doors { get; set; }

        Vector2Int LeftTopPos{ get; set; }

        void Init(Vector2Int position);
        void CreateNeighbouringRoom(Vector2Int Direction);
    }

}
