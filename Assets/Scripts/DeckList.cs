using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckList : MonoBehaviour
{
    //public List<SoliderCardData> soliderCardList = new List<SoliderCardData>();
    public List<SoliderCard> soliderCardList = new List<SoliderCard>();
    public List<VenueCard> venueCardList = new List<VenueCard>();
    public Text txtDeck;
    void Start()
    {
        //將list的所有卡片顯示在卡片清單中
        for (int i = 0; i < soliderCardList.Count; i++)
        {
            Instantiate(soliderCardList[i], transform.position, Quaternion.identity, transform.GetChild(1)
              .GetChild(0).GetChild(0).GetChild(0));
        }
        for (int i = 0; i < venueCardList.Count; i++)
        {
            Instantiate(venueCardList[i], transform.position, Quaternion.identity, transform.GetChild(1)
              .GetChild(0).GetChild(0).GetChild(0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        txtDeck.text = (soliderCardList.Count + venueCardList.Count).ToString();
    }
}
