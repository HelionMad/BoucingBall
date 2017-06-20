using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Text TimeText;
    public Text WinnerText;

    private float timeLeft = 120.0f;

    void Start()
    {
        TimeText.text = "Time: " + timeLeft.ToString("0.0") + "s";
        GameObject.Find("GameOver").GetComponent<Text>().enabled = false;
        GameObject.Find("Winner").GetComponent<Text>().enabled = false;
        GameObject.Find("RestartBtn").GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 0.0f);
        GameObject.Find("ExitBtn").GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 0.0f);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 20.01f)
        {

             if (timeLeft < -0.00001f)
                {
                    timeLeft = 0.0f;
                    GameOver();
                }
        }
       
        TimeText.text = "Time: " + timeLeft.ToString("0.0") + "s";


    }

    void GameOver()
    {
        GameObject Player1 = GameObject.Find("Player1");
        Player1Controller Player1Controller = Player1.GetComponent<Player1Controller>();
        GameObject Player2 = GameObject.Find("Player2");
        Player2Controller Player2Controller = Player2.GetComponent<Player2Controller>();
        if (Player1Controller.count > Player2Controller.count)
        {
            WinnerText.text = "Winner is Player1";
        }
        else if (Player1Controller.count < Player2Controller.count)
        {
            WinnerText.text = "Winner is Player2";
        }
        else
        {
            WinnerText.text = "Draw";
        }
        GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
        GameObject.Find("Winner").GetComponent<Text>().enabled = true;
        GameObject.Find("GameTime").GetComponent<Text>().enabled = false;
        GameObject.Find("Player1").SetActive(false);
        GameObject.Find("Player2").SetActive(false);
        GameObject.Find("RestartBtn").GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f, 30.0f);
        GameObject.Find("ExitBtn").GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f, 30.0f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Application.LoadLevel("minigame");
    }
}