using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    public GameObject player;
    public void GoMain() //���ξ����� �̵�
    {
        SceneManager.LoadScene("Main");
    }

    public void Replay() //����� �ٽ� �ε��ϱ�
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoStage1() //��������1�� �̵�
    {
        SceneManager.LoadScene("Stage1");
    }

    public void GoStage2() //��������2�� �̵�
    {
        SceneManager.LoadScene("Stage2");
    }
}
