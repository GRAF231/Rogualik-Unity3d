using UnityEngine;

namespace TheGame.Map
{
    interface IDoor
    {
        byte Horizontal { get; set; }
        Vector2Int Direction { get; set; }
        void Open();
    }
}
