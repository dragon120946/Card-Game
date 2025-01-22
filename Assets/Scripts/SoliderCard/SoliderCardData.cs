using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Solider", menuName ="Card/Solider")]
public class SoliderCardData : ScriptableObject
{
    public int number;
    public string cardName;
    public Sprite cardSprite;
    public int energy;
    public int health;
    public int attack;
    public int move;
    public int attackRange;
    public string empire;
    public Sprite soliderSprite;

    public bool canFly;
    public bool canSwim;
}
