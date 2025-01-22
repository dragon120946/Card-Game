using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VenueInfo : MonoBehaviour
{
    private VenueCardData VenueCardData;
    [SerializeField] private VenueCard venueCard;
    [SerializeField] private Text txtInfo;
    // Start is called before the first frame update
    void Start()
    {
        VenueCardData = venueCard.venueCardData;
    }

    // Update is called once per frame
    void Update()
    {
        txtInfo.text = VenueCardData.ability;
    }
}
