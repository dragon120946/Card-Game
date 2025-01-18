using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VenueCard : CardInteractive
{
    public VenueCardData venueCardData;

    //�d��
    public Image imgCardSprite;
    //��q�Ϥ�
    public Image imgHp;
    //�����Ϥ�
    public Image imgAttack;
    //���ʤO�Ϥ�
    public Image imgMove;
    //�ˮ`�q�Ϊv���q
    public Text txtHp;
    //�W�˩δ��
    public Text txtAttack;
    //���ʤO�W�δ�
    public Text txtMove;

    //�n���ܪ��Ϥ�
    public Sprite hurtSprite;       //�ˮ`�Ϥ�
    public Sprite healSprite;       //�v���Ϥ� 
    public Sprite atkUpSprite;      //�W�˹Ϥ�
    public Sprite atkDownSprite;    //��˹Ϥ�
    public Sprite spdUpSprite;      //�[�t�Ϥ�
    public Sprite spdDownSprite;    //��t�Ϥ�

    void Start()
    {
        Base_Start();
        imgCardSprite.sprite = venueCardData.cardSprite;
        txtHp.text = venueCardData.hpCount.ToString();
        txtAttack.text = venueCardData.atkCount.ToString();
        txtMove.text = venueCardData.spdCount.ToString();

        #region �ˮ`�Ϊv���P�w
        if (venueCardData.dmage != true && venueCardData.heal != true)
        {
            imgHp.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgHp.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCardData.dmage == true)
        {
            imgHp.sprite = hurtSprite;
        }
        else if (venueCardData.heal == true)
        {
            imgHp.sprite = healSprite;
        }
        #endregion

        #region �W�˩δ�˧P�w
        if (venueCardData.atkUp != true && venueCardData.atkDown != true)
        {
            imgAttack.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgAttack.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCardData.atkUp == true)
        {
            imgAttack.sprite = atkUpSprite;
        }
        else if (venueCardData.atkDown == true)
        {
            imgAttack.sprite = atkDownSprite;
        }
        #endregion

        #region �[�t�δ�t�P�w
        if (venueCardData.spdUp != true && venueCardData.spdDown != true)
        {
            imgMove.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            imgMove.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (venueCardData.spdUp == true)
        {
            imgMove.sprite = spdUpSprite;
        }
        else if (venueCardData.spdDown == true)
        {
            imgMove.sprite = spdDownSprite;
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
