using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Solider", menuName = "Card/Solider")]
public class SoliderCardData : ScriptableObject
{
    public Card 卡片資訊;
    [System.Serializable]
    public class Card
    {
        public int id;
        public string cardName;
        public Sprite cardSprite;
        public int energy;
        public int health;
        public int attack;
        public int move;
        public int attackRange;
        public string empire;
        public Sprite soliderSprite;
        public cardMovement 卡片移動方式;
        [Flags]
        public enum cardMovement
        {
            不能移動 = 0,可以路行 = 1, 可以游泳 = 2, 可以飛行 = 4
        }
    }

}
