using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheGame.Map
{
    class Room : IRoom, IDisposable
    {
        public byte[,] RoomMap { get; set; }
        public List<IDoor> Doors { get; set; }
        public Vector2Int LeftTopPos { get; set; }

        IWorld world;

        public Room(IWorld world)
        {
            this.world = world;
        }
        static bool isInit = false;


        public void Init(Vector2Int position)
        {
            Doors = new List<IDoor>();
            LeftTopPos = position;

            //if (world.Map[LeftTopPos.x, LeftTopPos.y] == 1)
            //{
            //    Dispose();
            //    return;
            //}

            RoomMap = new byte[9, 9]
            {
                { 1, 1, 1, 1, 2, 1, 3, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 2, 0, 0, 0, 0, 0, 0, 0, 2 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 3, 1, 2, 1, 1, 1, 1 }
            };

            if (!isInit)
            {
                isInit = true;
                CreateNeighbouringRoom(new Vector2Int(0, 1));
                CreateNeighbouringRoom(new Vector2Int(1, 0));
            }
        }


        public void CreateNeighbouringRoom(Vector2Int direction)
        {

            Doors.Add(new Door(this));
            world.CreateRoom(LeftTopPos, direction);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
