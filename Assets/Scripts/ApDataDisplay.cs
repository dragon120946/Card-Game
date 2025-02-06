using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ApDataDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameManager gameManager;
    private Slider slidAp;
    [SerializeField]private Text txtData;
    // Start is called before the first frame update
    void Start()
    {
        slidAp = gameObject.GetComponent<Slider>();
        txtData.gameObject.SetActive(false);
    }
    //滑鼠進入時，顯示AP數值
    public void OnPointerEnter(PointerEventData eventData)
    {
        txtData.gameObject.SetActive(true);
        txtData.text = gameManager.slidAp.value + " / " + gameManager.slidAp.maxValue;
    }
    //滑鼠離開時，恢復原狀
    public void OnPointerExit(PointerEventData eventData)
    {
        txtData.gameObject.SetActive(false);
    }
}
