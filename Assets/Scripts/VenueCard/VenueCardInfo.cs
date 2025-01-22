using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //和場地卡連動
        txtCard.text = venueCard.venueCardData.cardName;
        imgCardSprite.sprite = venueCard.venueCardData.cardSprite;
        txtHp.text = venueCard.venueCardData.hpCount.ToString();
        txtAttack.text = venueCard.venueCardData.atkCount.ToString();
        txtMove.text = venueCard.venueCardData.spdCount.ToString();
        imgHp.sprite = venueCard.imgHp.sprite;
        imgAttack.sprite = venueCard.imgAttack.sprite;
        imgMove.sprite = venueCard.imgMove.sprite;

        #region 傷害或治療判定
        if (venueCard.venueCardData.dmage != true && venueCard.venueCardData.heal != true)
        {
            imgHp.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgHp.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCard.venueCardData.dmage == true)
        {
            imgHp.sprite = venueCard.hurtSprite;
        }
        else if (venueCard.venueCardData.heal == true)
        {
            imgHp.sprite = venueCard.healSprite;
        }
        #endregion

        #region 增傷或減傷判定
        if (venueCard.venueCardData.atkUp != true && venueCard.venueCardData.atkDown != true)
        {
            imgAttack.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgAttack.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCard.venueCardData.atkUp == true)
        {
            imgAttack.sprite = venueCard.atkUpSprite;
        }
        else if (venueCard.venueCardData.atkDown == true)
        {
            imgAttack.sprite = venueCard.atkDownSprite;
        }
        #endregion

        #region 加速或減速判定
        if (venueCard.venueCardData.spdUp != true && venueCard.venueCardData.spdDown != true)
        {
            imgMove.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgMove.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCard.venueCardData.spdUp == true)
        {
            imgMove.sprite = venueCard.spdUpSprite;
        }
        else if (venueCard.venueCardData.spdDown == true)
        {
            imgMove.sprite = venueCard.spdDownSprite;
        }
        #endregion

        txtInfo.text = venueCard.venueCardData.ability;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
