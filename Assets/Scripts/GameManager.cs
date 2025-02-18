using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int turn;
    public static int ap;

    public bool isMyTurn;
    public bool isEnemyTurn;
    private bool alreadyTriggered = false;
    private int n;
    private int x;
    public Button btnTurnEnd;
    public Slider slidAp;
    public Scrollbar scollDayAndNight;
    public Text txtDay;

    // Start is called before the first frame update
    void Start()
    {
        turn = 1;
        ap = (int)slidAp.value;
        slidAp.maxValue = 0;
        btnTurnEnd.onClick.AddListener(OnBtnTurnEndClick);
    }

    // Update is called once per frame
    void Update()
    {

        n = Mathf.RoundToInt(turn / 2);
        x = Mathf.RoundToInt(n / 2);

        //若回合數為奇數，則為我方回合；若回合數為偶數，則為敵方回合
        //Debug.Log("turn:" + turn);
        //Debug.Log("n:" + n);
        if (turn == n * 2 + 1)
        {
            isMyTurn = true;
            isEnemyTurn = false;
        }
        else if(turn == n * 2)
        {
            isEnemyTurn = true;
            isMyTurn = false;
        }

        //我方回合才可行動
        if (isMyTurn)
        {
            btnTurnEnd.interactable = true;
            TurnStart();
        }
        //敵方回合時，我方無法結束回合
        if (isEnemyTurn)
        {
            btnTurnEnd.interactable = false;
        }

        #region 晝夜判定
        if (n == 0 || n == x * 2 && isMyTurn)
        {
            scollDayAndNight.value = 0f;
        }
        else if (n == x * 2 + 1 && isEnemyTurn)
        {
            scollDayAndNight.value = 0.33f;
        }
        else if (n == x * 2 + 1 && isMyTurn)
        {
            scollDayAndNight.value = 0.66f;
        }
        else if (n == x * 2 && isEnemyTurn)
        {
            scollDayAndNight.value = 1f;
        }
        #endregion

        #region 天數判定
        if (n == 0)
        {
            txtDay.text = "第 1 天";
        }
        else if (n == x * 2 && isMyTurn)
        {
            txtDay.text = "第 " + (x + 1) + " 天";
        }
        #endregion

        //回合開始時回滿AP後才可消耗AP
        if (alreadyTriggered)
        {
            slidAp.value = ap;
        }

        //測試用
        if (Input.GetKeyDown(KeyCode.Z))
        {
            turn++;
            alreadyTriggered = false;
        }
    }

    void OnBtnTurnEndClick()
    {
        TurnEnd();
    }
    void TurnStart() 
    {
        if (alreadyTriggered)
        {
            return;
        }
        else
        {
            //回合開始時，AP直到4前最大值加1，回滿AP
            slidAp.maxValue++;
            slidAp.maxValue = Mathf.Clamp(slidAp.maxValue, 0, 4);
            slidAp.value = ap = (int)slidAp.maxValue;
        }
        alreadyTriggered = true;
    }
    void TurnEnd()
    {
        turn++;
        alreadyTriggered = false;
    }
}
