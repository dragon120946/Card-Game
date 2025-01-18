using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Venue", menuName = "Card/Venue")]
public class VenueCardData : ScriptableObject
{
    public int number;
    public string cardName;
    public Sprite cardSprite;
    [Multiline]
    public string ability;

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
