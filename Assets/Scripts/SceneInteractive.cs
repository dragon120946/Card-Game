using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneInteractive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //[System.NonSerialized]public bool canPlaceCard;   //是否可以放置卡
    private VenueCardData venueCardData;
    [SerializeField]private VenueCard venueCard;
    public SoliderActive solider;

    [SerializeField]private GameObject venueInfo;
    private Image imgVenue;
    private Sprite originSprite;
    //public GameObject[] venueList = new GameObject[27];

    void Start()
    {
        venueCardData = venueCard.venueCardData;
        imgVenue = gameObject.GetComponent<Image>();
        originSprite = gameObject.GetComponent<Image>().sprite;
    }

    void Update()
    {
        //(還沒驗證過是否可行)

        #region 血量判定
        if (venueCardData.dmage)
        {
            solider.hp -= venueCardData.hpCount;
        }
        else if (venueCardData.heal)
        {
            solider.hp += venueCardData.hpCount;
        }
        #endregion

        #region 攻擊力判定
        if (venueCardData.atkUp)
        {
            solider.atk += venueCardData.atkCount;
        }
        else if (venueCardData.atkDown)
        {
            solider.atk -= venueCardData.atkCount;
        }
        #endregion

        #region 移動力判定
        if (venueCardData.spdUp)
        {
            solider.spd += venueCardData.spdCount;
        }
        else if (venueCardData.spdDown)
        {
            solider.spd -= venueCardData.spdCount;
        }
        #endregion

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
            info = Instantiate(venueInfo, gameObject.transform.position + new Vector3(0f, 200f, 0f),
            Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(info);
    }
    GameObject info;

    #endregion

}
