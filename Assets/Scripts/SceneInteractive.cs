using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneInteractive : MonoBehaviour
{
    [System.NonSerialized]public bool canPlaceCard;   //是否可以放置卡
    public GameObject[] venueList = new GameObject[27];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (venueList[0].gameObject.transform.childCount == 0)
        {
            canPlaceCard = true;
        }
        else
        {
            canPlaceCard = false;
        }

        if (canPlaceCard == true)
        {
            gameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }
}
