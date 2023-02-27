using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScoreText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Enemy.EnemyDead == 0)
        {
        }
        else
        {
            GetComponent<TMP_Text>().text = Enemy.EnemyDead.ToString();
        }
    }
}
