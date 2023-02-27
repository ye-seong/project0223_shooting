using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowCoinText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Player.CoinCount == 0)
        {
        }
        else
        {
            GetComponent<TMP_Text>().text = Player.CoinCount.ToString();
        }
    }
}
