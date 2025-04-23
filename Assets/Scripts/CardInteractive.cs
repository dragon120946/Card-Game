using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 卡片相關互動
/// </summary>

public class CardInteractive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    ,IBeginDragHandler, IDragHandler, IEndDragHandler
{ 
    public GameObject cardInfo;             //卡片詳細
    public GameObject solider;              //士兵prefeb
    public DeckData deckData;               //牌組數據

    private Vector2 origPos;                //原位置
    private Transform originParent;         //父物件
    private RectTransform currentTrans;     //UI transform
    private CanvasGroup canvasGroup;

    public void Base_Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        currentTrans = GetComponent<RectTransform>();
    }
    #region 滑鼠進出事件

    //滑鼠碰到時，凸顯卡片位置並顯示卡片細節
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("c");
        transform.position += new Vector3(0, 50f, 0);
        info = Instantiate(cardInfo, transform.position + new Vector3(0f, 300f, 0f), 
            Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform);
        switch (gameObject.tag)
        {
            case "SoliderCard":
                //Debug.Log("讀取士兵數據");
                info.GetComponent<SoliderCardInfo>().讀取數據(gameObject.GetComponent<SoliderCard>().soliderCardData.卡片資訊);
                break;

            case "VenueCard":
                //Debug.Log("讀取場地數據");
                info.GetComponent<VenueCardInfo>().讀取數據(gameObject.GetComponent<VenueCard>().venueCardData.卡片資訊);
                break;
        }
    }
    //滑鼠離開時，恢復原狀
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position -= new Vector3(0, 50f, 0);
        Destroy(info);
    }
    GameObject info;

    #endregion

    #region 滑鼠拖曳事件

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        origPos = currentTrans.position - new Vector3(0, 50f, 0); 
        if (gameObject.transform.parent.name == "CardLayout")
        {
            originParent = transform.parent;
            transform.SetParent(transform.parent);
        }
        else if (gameObject.transform.parent.name == "Content")
        {
            originParent = transform.parent;
            transform.SetParent(transform.parent.parent.parent.parent);
        }
       
    }
    public void OnDrag(PointerEventData eventData)
    {
        currentTrans.position = eventData.position;
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.SetParent(originParent);
        currentTrans.position = origPos;

        #region 和場地的互動

        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Scene"))
        {
            canvasGroup.blocksRaycasts = true;

            //如果是士兵卡，生成角色到該位置;如果是場地卡，改變該位置的場地
            if (gameObject.tag == "SoliderCard"&& gameObject.GetComponent<SoliderCard>().soliderCardData.卡片資訊.energy 
                <= GameManager.ap)
            {
                SoliderCardData 來源 = gameObject.GetComponent<SoliderCard>().soliderCardData;
                SoliderCardData.Card 資訊 = gameObject.GetComponent<SoliderCard>().soliderCardData.卡片資訊;
                GameObject soliderObj;
                //Debug.Log("b");
                
                soliderObj = Instantiate(solider, eventData.pointerCurrentRaycast.gameObject
                    .transform.position, Quaternion.identity, eventData.pointerCurrentRaycast
                    .gameObject.transform);
                //設置角色初始數據
                soliderObj.GetComponent<SoliderActive>().soliderCardData = 來源;
                soliderObj.GetComponent<SoliderActive>().imgSolider.sprite = 資訊.soliderSprite;
                soliderObj.GetComponent<SoliderActive>().txtData.text = 資訊.attack.ToString() + " / " +
                資訊.health.ToString();

                soliderObj.GetComponent<SoliderActive>().txtSpd.text = 資訊.move.ToString();
                //AP減少所需數值
                GameManager.ap -= 資訊.energy;

                Destroy(gameObject);
            }
            else if (gameObject.tag == "VenueCard" && GameManager.ap != 0)
            {
                //改變場地圖片
                Debug.Log("a");
                VenueCardData 來源 = gameObject.GetComponent<VenueCard>().venueCardData;
                VenueCardData.Card 資訊 = gameObject.GetComponent<VenueCard>().venueCardData.卡片資訊;
                eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite
                    = 資訊.venueSprite;
                eventData.pointerCurrentRaycast.gameObject.GetComponent<SceneInteractive>().venueCardData = 來源;

                //AP全消耗
                GameManager.ap = 0;
                Destroy(gameObject);
            }
            else
            {
                //如果AP超過現有AP則無法放置
                transform.SetParent(originParent);
                currentTrans.position = origPos;
            }
        }
        #endregion

        #region 牌組和持有卡的數據轉換
        //改變卡片位置
        if (eventData.pointerCurrentRaycast.gameObject.name == "DeckViewport" ||
           eventData.pointerCurrentRaycast.gameObject.name == "CardViewport")
        {
            currentTrans.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0));
            currentTrans.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
        }
        //改變數據
        switch (eventData.pointerCurrentRaycast.gameObject.name)
        {
            case "DeckViewport":
   
                switch (gameObject.tag)
                {
                    case "SoliderCard":
                        deckData.soliderCardDataList.Add(gameObject.GetComponent<SoliderCard>().soliderCardData);
                        break;

                    case "VenueCard":
                        deckData.venueCardDataList.Add(gameObject.GetComponent<VenueCard>().venueCardData);
                        break;
                }

                break;

            case "CardViewport":
                switch (gameObject.tag)
                {
                    case "SoliderCard":
                        deckData.soliderCardDataList.Remove(gameObject.GetComponent<SoliderCard>().soliderCardData);
                        break;

                    case "VenueCard":
                        deckData.venueCardDataList.Remove(gameObject.GetComponent<VenueCard>().venueCardData);
                        break;
                }
                break;
        }
        #endregion
    }
    #endregion
}