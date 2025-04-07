using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 讀取場地卡資訊並顯示
/// </summary>
public class VenueCardInfo : MonoBehaviour
{
    [SerializeField] private VenueCard venueCard;

    //卡片名稱
    [SerializeField] private Text txtCard;
    //卡圖
    [SerializeField] private Image imgCardSprite;
    //血量圖片
    [SerializeField] private Image imgHp;
    //攻擊圖片
    [SerializeField] private Image imgAttack;
    //移動力圖片
    [SerializeField] private Image imgMove;
    //傷害量或治療量
    [SerializeField] private Text txtHp;
    //增傷或減傷
    [SerializeField] private Text txtAttack;
    //移動力增或減
    [SerializeField] private Text txtMove;
    //效果文字
    [SerializeField] private Text txtInfo;

    // Start is called before the first frame update
    void Start()
    {
        
        #region 傷害或治療判定
        if (venueCard.venueCardData.卡片資訊.dmage != true && venueCard.venueCardData.卡片資訊.heal != true)
        {
            imgHp.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgHp.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCard.venueCardData.卡片資訊.dmage == true)
        {
            imgHp.sprite = venueCard.hurtSprite;
        }
        else if (venueCard.venueCardData.卡片資訊.heal == true)
        {
            imgHp.sprite = venueCard.healSprite;
        }
        #endregion

        #region 增傷或減傷判定
        if (venueCard.venueCardData.卡片資訊.atkUp != true && venueCard.venueCardData.卡片資訊.atkDown != true)
        {
            imgAttack.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgAttack.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCard.venueCardData.卡片資訊.atkUp == true)
        {
            imgAttack.sprite = venueCard.atkUpSprite;
        }
        else if (venueCard.venueCardData.卡片資訊.atkDown == true)
        {
            imgAttack.sprite = venueCard.atkDownSprite;
        }
        #endregion

        #region 加速或減速判定
        if (venueCard.venueCardData.卡片資訊.spdUp != true && venueCard.venueCardData.卡片資訊.spdDown != true)
        {
            imgMove.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgMove.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCard.venueCardData.卡片資訊.spdUp == true)
        {
            imgMove.sprite = venueCard.spdUpSprite;
        }
        else if (venueCard.venueCardData.卡片資訊.spdDown == true)
        {
            imgMove.sprite = venueCard.spdDownSprite;
        }
        #endregion

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void 讀取數據(VenueCardData.Card 數據)
    {
        //和場地卡連動
        txtCard.text = 數據.cardName;
        imgCardSprite.sprite = 數據.cardSprite;
        txtHp.text = 數據.hpCount.ToString();
        txtAttack.text = 數據.atkCount.ToString();
        txtMove.text = 數據.spdCount.ToString();
        imgHp.sprite = venueCard.imgHp.sprite;
        imgAttack.sprite = venueCard.imgAttack.sprite;
        imgMove.sprite = venueCard.imgMove.sprite;
        txtInfo.text = 數據.ability;
    }
}
