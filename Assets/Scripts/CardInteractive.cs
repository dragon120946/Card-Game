using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardInteractive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    ,IBeginDragHandler, IDragHandler, IEndDragHandler
{ 
    public GameObject CardInfo;
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
        info = Instantiate(CardInfo, new Vector3(960f, 700f, 0f), 
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
        transform.SetParent(originParent);
        //transform.position = originParent.position;
        canvasGroup.blocksRaycasts = true;
        currentTrans.position = origPos;
    }

}
