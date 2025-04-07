using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoliderCard : CardInteractive
{
    public SoliderCardData soliderCardData;
    //卡圖
    public Image imgCardSprite;
    //能量
    public Text txtEnergy;
    //血量
    public Text txtHp;
    //攻擊力
    public Text txtAttack;
    // Start is called before the first frame update
    void Start()
    {
        Base_Start();
        imgCardSprite.sprite = soliderCardData.卡片資訊.cardSprite;
        txtEnergy.text = soliderCardData.卡片資訊.energy.ToString();
        txtHp.text = soliderCardData.卡片資訊.health.ToString();
        txtAttack.text = soliderCardData.卡片資訊.attack.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
