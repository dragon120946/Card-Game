using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 抓取數據庫的數據並顯示
/// </summary>

public class SoliderCardInfo : MonoBehaviour
{
    [SerializeField]SoliderCard soliderCard;
    //卡片名稱
    [SerializeField] private Text txtCard;
    //卡圖
    [SerializeField] private Image imgCardSprite;
    //能量
    [SerializeField] private Text txtEnergy;
    //血量
    [SerializeField] private Text txtHp;
    //攻擊力
    [SerializeField] private Text txtAttack;
    //陣營
    [SerializeField] private Image imgEmpire;
    //士兵性能
    [SerializeField] private Image imgPerformance;
    //移動力
    [SerializeField] private Slider slidMove;
    //攻擊範圍
    [SerializeField] private Slider slidAtkRng;
    //要改變的圖片
    public Sprite humanSprite;      //人族圖片
    public Sprite animalSprite;     //動物族圖片 
    public Sprite walkSprite;       //步行圖片
    public Sprite flySprite;        //飛行圖片
    public Sprite swimSprite;       //游泳圖片

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void 讀取數據(SoliderCardData.Card 數據)
    {
        //和士兵卡連動
        txtCard.text = 數據.cardName;
        imgCardSprite.sprite = 數據.cardSprite;
        txtEnergy.text = 數據.energy.ToString();
        txtHp.text = 數據.health.ToString();
        txtAttack.text = 數據.attack.ToString();
        slidMove.value = 數據.move;
        slidAtkRng.value = 數據.attackRange;

        if (數據.empire == "human")
        {
            imgEmpire.sprite = humanSprite;
        }
        else if (數據.empire == "animal")
        {
            imgEmpire.sprite = animalSprite;
        }

        imgPerformance.sprite = walkSprite;
    }
}
