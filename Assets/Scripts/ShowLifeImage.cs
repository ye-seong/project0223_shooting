using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLifeImage : MonoBehaviour
{
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject GameOver;
    public GameObject ReplayButton;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.GetComponent<Image>().enabled = false;
        ReplayButton.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.life == 2)
        {
            Life1.GetComponent<Image>().enabled = false;
        }
        if (Player.life == 1)
        {
            Life2.GetComponent<Image>().enabled = false;
        }
        if (Player.life == 0)
        {
            Life3.GetComponent<Image>().enabled = false;
            GameOver.GetComponent<Image>().enabled = true;
            ReplayButton.GetComponent<Image>().enabled = true;
        }
    }
}
