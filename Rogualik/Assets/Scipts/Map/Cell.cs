using System.Collections;
using System.Collections.Generic;
using TheGame;
using UnityEngine;

namespace TheGame
{
    public class Cell : MonoBehaviour
    {
        private Sprite sprite;
        void Start()
        {
            sprite = Game.GetRandomSprite();
            GetComponent<SpriteRenderer>().sprite = sprite;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}