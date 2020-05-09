using UnityEngine;

namespace TheGame
{
    public class Game
    {
        private static Sprite[] AllSprites { get; set; }

        static Game()
        {
            AllSprites = Resources.LoadAll<Sprite>("sprites");
        }

        public static Sprite GetSprite(int idSprite)
        {
            return AllSprites[idSprite];
        }

        public static Sprite GetRandomSprite()
        {
            return AllSprites[Random.Range(0, AllSprites.Length - 1)];
        }
    }
}