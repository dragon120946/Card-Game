using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VenueInfo : MonoBehaviour
{
    [SerializeField] private VenueCard venueCard;
    [SerializeField] private Text txtInfo;
    // Start is called before the first frame update
    void Start()
    {
        txtInfo.text = venueCard.venueCardData.卡片資訊.ability;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void 讀取數據(VenueCardData.Card 數據)
    {
        Debug.Log("0");
        txtInfo.text = 數據.ability;
    }
}
