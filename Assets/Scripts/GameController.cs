using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Declare global variables to be accessed throughout the game
    public static int scoreValue;
    public static int alienCount;
    public static int playerHealth;

    public Text score;
    public Text displayResult;
    public GameObject restartButton;

    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        //Initialy set the game variables
        alienCount = GameObject.FindGameObjectsWithTag("Alien").Length;
        Time.timeScale = 1;
        scoreValue = 0;
        gameOver = false;
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Display the score on the UI
        score.text = "Score: " + scoreValue;

        //Detecting Winning Condition
        if (scoreValue >= alienCount && !gameOver)
        {
            displayResult.text = "Congratulations You Won!";
            gameOver = true;
            Time.timeScale = 0;
            restartButton.SetActive(true);
        }

        //Detecting Loosing Condition
        if (playerHealth == 0 && !gameOver)
        {
            displayResult.text = "You Lose!";
            gameOver = true;
            Time.timeScale = 0;
            restartButton.SetActive(true);
        }
    }


    public void RestartGame()
    {
        //If player would like to play again reload the game scene
        SceneManager.LoadScene("SpaceInvaders");

    }
}
