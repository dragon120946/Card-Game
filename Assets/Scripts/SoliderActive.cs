using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 場地上的士兵
/// </summary>

public class SoliderActive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SoliderCardData soliderCardData;
    GameObject cardInfo;
    [SerializeField] SoliderCard soliderCard;   //士兵卡

    public Text txtData;                        //士兵攻防文字
    public Text txtSpd;                         //士兵移動力文字
    public Image imgSolider;                    //士兵圖片

    [System.NonSerialized]public int hp;        //士兵生命
    [System.NonSerialized] public int atk;      //士兵攻擊
    [System.NonSerialized] public int spd;      //士兵移動力
    public Slider slidCounter;                  //回合計數器
    private bool canMove;                       //是否能移動

    // Start is called before the first frame update
    void Start()
    {
        cardInfo = soliderCard.cardInfo;
        hp = soliderCardData.卡片資訊.health;
        atk = soliderCardData.卡片資訊.attack;
        spd = soliderCardData.卡片資訊.move;
    }

    // Update is called once per frame
    void Update()
    {

    #region 移動相關判定
        //如果移動力有變動，顯示目前移動力
        if (spd != soliderCardData.卡片資訊.move)
        {
            txtSpd.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            txtSpd.transform.parent.gameObject.SetActive(false);
        }
        //如果移動力歸0，無法移動並顯示計數器
        if (spd <= 0 && slidCounter.value < 2)
        {
            slidCounter.gameObject.SetActive(true);
            canMove = false;
        }
        else
        {
            slidCounter.gameObject.SetActive(false);
            canMove = true;
        }
    #endregion

        /*
        txtData.text = soliderCard.soliderCardData.attack.ToString() + " / " +
            soliderCard.soliderCardData.health.ToString();
        txtSpd.text = soliderCard.soliderCardData.move.ToString();
        */
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        info = Instantiate(cardInfo, transform.position + new Vector3(0f, 350f, 0f),
            Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        info.GetComponent<SoliderCardInfo>().讀取數據(soliderCardData.卡片資訊);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(info);
    }
    GameObject info;
}
