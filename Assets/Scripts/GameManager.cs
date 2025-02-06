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
    public Button btnTurnEnd;
    public Slider slidAp;

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
        //若回合數為奇數，則為我方回合；若回合數為偶數，則為敵方回合
        //Debug.Log("turn:" + turn);
        int n = Mathf.RoundToInt(turn / 2);
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
            TurnStart();
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
            slidAp.value = slidAp.maxValue;
        }
        alreadyTriggered = true;
    }
    void TurnEnd()
    {
        turn++;
        alreadyTriggered = false;
    }
}
