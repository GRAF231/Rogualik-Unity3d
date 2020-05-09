using UnityEngine;

namespace TheGame.Map
{
    class Door : IDoor
    {
        private IRoom room;

        public byte Horizontal { get; set; }
        public Vector2Int Direction { get; set; }

        public Door(IRoom room)
        {
            this.room = room;            
        }

        public void Open()
        {
            room.CreateNeighbouringRoom(Direction);
        }
    }
}
