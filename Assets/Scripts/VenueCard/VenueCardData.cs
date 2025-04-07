using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Venue", menuName = "Card/Venue")]
public class VenueCardData : ScriptableObject
{
    public Card 卡片資訊;
    [System.Serializable]
    public class Card
    {
        public int id;
        public string cardName;
        public Sprite cardSprite;
        [Multiline]
        public string ability;
        public Sprite venueSprite;

        public bool dmage;
        public bool heal;
        public int hpCount;

        public bool atkUp;
        public bool atkDown;
        public int atkCount;

        public bool spdUp;
        public bool spdDown;
        public int spdCount;
    }
}
