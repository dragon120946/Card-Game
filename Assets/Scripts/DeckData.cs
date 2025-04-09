using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 牌組數據
/// </summary>
[CreateAssetMenu(fileName = "New Deck", menuName ="Deck")]
public class DeckData : ScriptableObject
{
    public List<SoliderCardData> soliderCardDataList = new List<SoliderCardData>();
    public List<VenueCardData> venueCardDataList = new List<VenueCardData>();
}
