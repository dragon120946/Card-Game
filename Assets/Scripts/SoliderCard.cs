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
        imgCardSprite.sprite = soliderCardData.cardSprite;
        txtEnergy.text = soliderCardData.energy.ToString();
        txtHp.text = soliderCardData.health.ToString();
        txtAttack.text = soliderCardData.attack.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
