using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 場地的互動
/// </summary>
public class SceneInteractive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //[System.NonSerialized]public bool canPlaceCard;   //是否可以放置卡
    public VenueCardData venueCardData;             //
    public SoliderActive solider;

    [SerializeField]private GameObject venueInfo;
    private Image imgVenue;
    //[SerializeField]private Text txtInfo;
    private Sprite originSprite;
    //public GameObject[] venueList = new GameObject[27];

    void Start()
    {
        imgVenue = gameObject.GetComponent<Image>();
        originSprite = gameObject.GetComponent<Image>().sprite;
    }

    void Update()
    {
        //(還沒驗證過是否可行)
        /*
        #region 血量判定
        if (venueCardData.卡片資訊.dmage)
        {
            solider.hp -= venueCardData.卡片資訊.hpCount;
        }
        else if (venueCardData.卡片資訊.heal)
        {
            solider.hp += venueCardData.卡片資訊.hpCount;
        }
        #endregion

        #region 攻擊力判定
        if (venueCardData.卡片資訊.atkUp)
        {
            solider.atk += venueCardData.卡片資訊.atkCount;
        }
        else if (venueCardData.卡片資訊.atkDown)
        {
            solider.atk -= venueCardData.卡片資訊.atkCount;
        }
        #endregion
        
        #region 移動力判定
        if (venueCardData.卡片資訊.spdUp)
        {
            solider.spd += venueCardData.卡片資訊.spdCount;
        }
        else if (venueCardData.卡片資訊.spdDown)
        {
            solider.spd -= venueCardData.卡片資訊.spdCount;
        }
        #endregion
        */
        /*
        if (venueList[0].gameObject.transform.childCount == 0)
        {
            canPlaceCard = true;
        }
        else
        {
            canPlaceCard = false;
        }

        if (canPlaceCard == true)
        {
            gameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
        */
    }

    #region 滑鼠進出事件

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (imgVenue.sprite == originSprite)
        {
            return;
        }
        else
        {
            info = Instantiate(venueInfo.transform.GetChild(9).gameObject, gameObject.transform.position + new Vector3(0f, 200f, 0f),
            Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
            Debug.Log("0");
            info.GetComponent<VenueCardInfo>().讀取數據(venueCardData.卡片資訊);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(info);
    }
    GameObject info;

    #endregion
}
