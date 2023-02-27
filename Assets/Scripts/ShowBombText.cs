using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowBombText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Player.BombCount == 0)
        {
        }
        else
        {
            GetComponent<TMP_Text>().text = Player.BombCount.ToString();
        }
    }
}
