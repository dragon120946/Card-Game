using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardInteractive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    ,IBeginDragHandler, IDragHandler, IEndDragHandler
{ 
    public GameObject cardInfo;             //卡片詳細
    public GameObject solider;              //士兵prefeb
    
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
        Debug.Log("c");
        transform.position += new Vector3(0, 50f, 0);
        info = Instantiate(cardInfo, transform.position + new Vector3(0f, 350f, 0f), 
            Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform);
        switch (gameObject.tag)
        {
            case "SoliderCard":
                Debug.Log("讀取士兵數據");
                info.GetComponent<SoliderCardInfo>().讀取數據(gameObject.GetComponent<SoliderCard>().soliderCardData.卡片資訊);
                break;

            case "VenueCard":
                Debug.Log("讀取場地數據");
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
        originParent = transform.parent;
        origPos = currentTrans.position - new Vector3(0, 50f, 0); ;
        transform.SetParent(transform.parent);
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
                Debug.Log("b");
                
                soliderObj = Instantiate(solider, eventData.pointerCurrentRaycast.gameObject
                    .transform.position, Quaternion.identity, eventData.pointerCurrentRaycast
                    .gameObject.transform);
                //設置角色初始數據
                soliderObj.GetComponent<SoliderActive>().soliderCardData = 來源;
                soliderObj.GetComponent<SoliderActive>().imgSolider.sprite = 資訊.soliderSprite;
                soliderObj.GetComponent<SoliderActive>().txtData.text = 資訊.attack.ToString() + " / " +
                資訊.health.ToString();

                soliderObj.GetComponent<SoliderActive>().txtSpd.text =
                   資訊.move.ToString();
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

                //AP全消耗
                eventData.pointerCurrentRaycast.gameObject.GetComponent<SceneInteractive>().venueCardData = 來源;
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
    }
    #endregion
}