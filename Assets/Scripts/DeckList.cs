using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckList : MonoBehaviour
{
    public List<GameObject> cardList = new List<GameObject>();

    public Text txtDeck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtDeck.text = cardList.Count.ToString();
    }
}
