using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VenueCard : CardInteractive
{
    public VenueCardData venueCardData;

    //卡圖
    public Image imgCardSprite;
    //血量圖片
    public Image imgHp;
    //攻擊圖片
    public Image imgAttack;
    //移動力圖片
    public Image imgMove;
    //傷害量或治療量
    public Text txtHp;
    //增傷或減傷
    public Text txtAttack;
    //移動力增或減
    public Text txtMove;

    //要改變的圖片
    public Sprite hurtSprite;       //傷害圖片
    public Sprite healSprite;       //治療圖片 
    public Sprite atkUpSprite;      //增傷圖片
    public Sprite atkDownSprite;    //減傷圖片
    public Sprite spdUpSprite;      //加速圖片
    public Sprite spdDownSprite;    //減速圖片

    void Start()
    {
        Base_Start();
        imgCardSprite.sprite = venueCardData.卡片資訊.cardSprite;
        txtHp.text = venueCardData.卡片資訊.hpCount.ToString();
        txtAttack.text = venueCardData.卡片資訊.atkCount.ToString();
        txtMove.text = venueCardData.卡片資訊.spdCount.ToString();

        #region 傷害或治療判定
        if (venueCardData.卡片資訊.dmage != true && venueCardData.卡片資訊.heal != true)
        {
            imgHp.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgHp.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCardData.卡片資訊.dmage == true)
        {
            imgHp.sprite = hurtSprite;
        }
        else if (venueCardData.卡片資訊.heal == true)
        {
            imgHp.sprite = healSprite;
        }
        #endregion

        #region 增傷或減傷判定
        if (venueCardData.卡片資訊.atkUp != true && venueCardData.卡片資訊.atkDown != true)
        {
            imgAttack.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgAttack.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCardData.卡片資訊.atkUp == true)
        {
            imgAttack.sprite = atkUpSprite;
        }
        else if (venueCardData.卡片資訊.atkDown == true)
        {
            imgAttack.sprite = atkDownSprite;
        }
        #endregion

        #region 加速或減速判定
        if (venueCardData.卡片資訊.spdUp != true && venueCardData.卡片資訊.spdDown != true)
        {
            imgMove.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgMove.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCardData.卡片資訊.spdUp == true)
        {
            imgMove.sprite = spdUpSprite;
        }
        else if (venueCardData.卡片資訊.spdDown == true)
        {
            imgMove.sprite = spdDownSprite;
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
