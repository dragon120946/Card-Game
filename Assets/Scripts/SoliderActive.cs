using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoliderActive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    SoliderCardData soliderCardData;
    GameObject cardInfo;
    [SerializeField] SoliderCard soliderCard;

    public Text txtData;                        //�h�L�𨾤�r
    public Text txtSpd;                         //�h�L���ʤO��r

    [System.NonSerialized]public int hp;        //�h�L�ͩR
    [System.NonSerialized] public int atk;      //�h�L����
    [System.NonSerialized] public int spd;      //�h�L���ʤO
    public Slider slidCounter;                  //�^�X�p�ƾ�
    private bool canMove;                       //�O�_�ಾ��

    // Start is called before the first frame update
    void Start()
    {
        soliderCardData = soliderCard.soliderCardData;
        cardInfo = soliderCard.cardInfo;
        hp = soliderCardData.health;
        atk = soliderCardData.attack;
        spd = soliderCardData.move;
    }

    // Update is called once per frame
    void Update()
    {

    #region ���ʬ����P�w
        //�p�G���ʤO���ܰʡA��ܥثe���ʤO
        if (spd != soliderCardData.move)
        {
            txtSpd.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            txtSpd.transform.parent.gameObject.SetActive(false);
        }
        //�p�G���ʤO�k0�A�L�k���ʨ���ܭp�ƾ�
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
        info = Instantiate(cardInfo, new Vector3(960f, 700f, 0f),
            Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(info);
    }
    GameObject info;
}
