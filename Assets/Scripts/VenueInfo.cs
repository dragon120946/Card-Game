using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 場上的場地資訊顯示
/// </summary>
public class VenueInfo : MonoBehaviour
{
    [SerializeField] private Text txtInfo;
    // Start is called before the first frame update
    void Start()
    {
       
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
