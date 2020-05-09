using UnityEngine;
using UnityEngine.Tilemaps;

namespace TheGame.Map
{
    public class World : MonoBehaviour, IWorld
    {
        public Tilemap map, walls, doors;
        public TileBase doorTile, wallTile, baseTile, fanTile; 

        public int Size { get; set; }
        public byte[,] Map { get; set; }

        public void CreateRoom(Vector2Int prevRoomCoord, Vector2Int direction)
        {
            IRoom room = new Room(this);
            ICoridor coridor = null;

            var roomPos = new Vector2Int(0, 0);
            var corPos = new Vector2Int(0, 0);

            if (direction.x == -1)
            {
                roomPos = new Vector2Int(prevRoomCoord.x - 9 - 2, prevRoomCoord.y);
                corPos = new Vector2Int(roomPos.x + 9, prevRoomCoord.y + 3);
            }
            else if (direction.x== 1)
            {
                roomPos = new Vector2Int(prevRoomCoord.x + 9 + 2, prevRoomCoord.y);
                corPos = new Vector2Int(roomPos.x - 2, prevRoomCoord.y + 3);
            }
            else if (direction.y == 1)
            {
                roomPos = new Vector2Int(prevRoomCoord.x, prevRoomCoord.y + 9 + 2);
                corPos = new Vector2Int(roomPos.x + 3, prevRoomCoord.y + 9);
            }
            else if (direction.y == -1)
            {
                roomPos = new Vector2Int(prevRoomCoord.x, prevRoomCoord.y - 9 - 2);
                corPos = new Vector2Int(roomPos.x + 3, prevRoomCoord.y - 2);
            }

            room.Init(roomPos);
            if (corPos != new Vector2Int())
            {
                coridor = new Coridor();
                coridor.Init(corPos, direction);
            }

            if (room != null)
                AddRoomInMap(room, coridor);
        }

        public void Init()
        {
            Size = CONFIG.MAP_RENDER_SIZE;
            Map = new byte[Size, Size];


            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Map[i, j] = 255;

            CreateRoom(new Vector2Int(), new Vector2Int());

            Draw();
        }

        void AddRoomInMap(IRoom room, ICoridor coridor)
        {
            for (int i = room.LeftTopPos.x, x = 0; x < room.RoomMap.GetLength(0); i++, x++)
                for (int j = room.LeftTopPos.y, y = 0; y < room.RoomMap.GetLength(1); j++, y++)
                    Map[i, j] = room.RoomMap[x, y];

            if (coridor != null)
                for (int i = coridor.LeftTopPos.x, x = 0; x < coridor.CoridorMap.GetLength(0); i++, x++)
                    for (int j = coridor.LeftTopPos.y, y = 0; y < coridor.CoridorMap.GetLength(1); j++, y++)
                        Map[i, j] = coridor.CoridorMap[x, y];
        }

        void Draw()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    if (Map[i, j] == 0)
                        map.SetTile(new Vector3Int(i, j, 0), baseTile);
                    else if (Map[i, j] == 1)
                        walls.SetTile(new Vector3Int(i, j, 0), wallTile);
                    else if (Map[i, j] == 2)
                        doors.SetTile(new Vector3Int(i, j, 0), doorTile);
                    else if (Map[i, j] == 3)
                        walls.SetTile(new Vector3Int(i, j, 0), fanTile);
                    else
                        continue;
                }
        }

        void Start()
        {
            Init();
        }
    }
}


