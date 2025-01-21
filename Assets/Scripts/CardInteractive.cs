using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardInteractive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    ,IBeginDragHandler, IDragHandler, IEndDragHandler
{ 
    public GameObject cardInfo;
    public GameObject solider;

    public Vector2 origPos;
    public Transform originParent;
    private RectTransform currentTrans;
    private CanvasGroup canvasGroup;

    public void Base_Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        currentTrans = GetComponent<RectTransform>();
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.position += new Vector3(0, 50f, 0);
        info = Instantiate(cardInfo, new Vector3(960f, 700f, 0f), 
            Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position -= new Vector3(0, 50f, 0);
        Destroy(info);
    }
    GameObject info;

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
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.SetParent(originParent);
        currentTrans.position = origPos;

        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Scene"))
        {
            canvasGroup.blocksRaycasts = true;
            //如果是士兵卡，生成角色到該位置;如果是場地卡，改變位置的場地
            if (gameObject.tag == "SoliderCard")
            {
                Instantiate(solider, eventData.pointerCurrentRaycast.gameObject
                    .transform.position, Quaternion.identity, eventData.pointerCurrentRaycast
                    .gameObject.transform);
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
    }

}
