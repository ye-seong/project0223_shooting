using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    public GameObject player;
    public void GoMain() //메인씬으로 이동
    {
        SceneManager.LoadScene("Main");
    }

    public void Replay() //현재씬 다시 로드하기
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoStage1() //스테이지1로 이동
    {
        SceneManager.LoadScene("Stage1");
    }

    public void GoStage2() //스테이지2로 이동
    {
        SceneManager.LoadScene("Stage2");
    }
}
