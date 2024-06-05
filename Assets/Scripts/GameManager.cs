using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallControler ballControler;

    public int playerScore = 0;
    public int enemyScore = 0;
    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public int winPoints = 2;

    public bool aleatorio = false;

    public float scalePointWin = 0.9f;
    public float scalePointLose = 1.1f;

    public int paddleOriginalSize = 10;

    public KeyCode resetKey = KeyCode.R;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;

    void Start()
    {
        ResetGame();
    }
    public void ResetGame()
    {
        // Define as posições iniciais das raquetes
        playerPaddle.position = new Vector3(-7f, 0f, 0f);
        enemyPaddle.position = new Vector3(7f, 0f, 0f);

        playerPaddle.localScale = new Vector3(3f, 10f, 0f);
        enemyPaddle.localScale = new Vector3(3f, 10f, 0f);

        ballControler.ResetBall();

        playerScore = 0;
        enemyScore = 0;
        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        enemyPaddle = ScaleXPaddle(enemyPaddle, scalePointWin);
        playerPaddle = ScaleXPaddle(playerPaddle, scalePointLose);
        CheckWin();
    }
    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        playerPaddle = ScaleXPaddle(playerPaddle, scalePointWin);
        enemyPaddle = ScaleXPaddle(enemyPaddle, scalePointLose);
        CheckWin();
    }

    public void CheckWin()
    {
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            //ResetGame();
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true); 
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Vitória " + winner;
        SaveController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    }

    public Transform ScaleXPaddle(Transform paddle, float scaleValue)
    {
        Vector3 currentValues = paddle.localScale;
        currentValues.y *= scaleValue;
        paddle.localScale = currentValues;
        return paddle;
    }

    private void Update()
    {
        if (Input.GetKeyDown(resetKey))
        {
            ResetGame();
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
