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
        transform.position += new Vector3(0, 50f, 0);
        info = Instantiate(cardInfo, new Vector3(960f, 700f, 0f), 
            Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform);
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
            if (gameObject.tag == "SoliderCard")
            {
                GameObject soliderObj;
                soliderObj = Instantiate(solider, eventData.pointerCurrentRaycast.gameObject
                    .transform.position, Quaternion.identity, eventData.pointerCurrentRaycast
                    .gameObject.transform);
                //設置角色初始數據
                soliderObj.GetComponent<SoliderActive>().txtData.text = gameObject.GetComponent<SoliderCard>().
                    soliderCardData.attack.ToString() + " / " +
                gameObject.GetComponent<SoliderCard>().soliderCardData.health.ToString();

                soliderObj.GetComponent<SoliderActive>().txtSpd.text =
                    gameObject.GetComponent<SoliderCard>().soliderCardData.move.ToString();

                Destroy(gameObject);
            }
            else if (gameObject.tag == "VenueCard")
            {
                eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite
                    = gameObject.GetComponent<VenueCard>().venueCardData.cardSprite;
            }
            //transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            //currentTrans.position = eventData.pointerCurrentRaycast
            //.gameObject.transform.position;
        }
        #endregion
    }
    #endregion
}