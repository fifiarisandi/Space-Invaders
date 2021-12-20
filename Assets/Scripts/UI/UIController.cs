using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public int killCount = 0;
    public int totalDefeatedEnemy = 0;
    public float clearTimeAtLevel = 0f;
    public float timeLimit = 0f;
    public int level = 0;
    public bool isStartingNextLevel = false;

    [SerializeField] GameObject startGameCanvas;

    [SerializeField] GameObject gameScreen;

    [SerializeField] GameObject gameTextCanvas;
    [SerializeField] Text levelText;
    [SerializeField] Text timeLimitText;
    [SerializeField] Text defeatedEnemiesText;

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] Text defeatedEnemiesTextInGameOverCanvas;
    [SerializeField] Text LevelTextInGameOverCanvas;

    [SerializeField] GameObject enemies;
    [SerializeField] GameObject enemyGroupPrefab;
    [SerializeField] GameObject enemyGroup2Prefab;
    [SerializeField] GameObject enemyGroup3Prefab;


    public void Start()
    {
        level++;
    }

    public void Update()
    {
        //SetForNextLevel();
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            ShowGameOverCanvas();
        }
    }

    public void StartCountDown()
    {
        if (isStartingNextLevel == true)
        {
            timeLimit -= Time.time;
        }
    }

    public void KillCount()
    {
        killCount++;
        totalDefeatedEnemy++;
    }

    public void ClearTime()
    {
        clearTimeAtLevel = Time.time;
    }

    public void SetForNextLevel()
    {
        if ((killCount >= (27 * level)) && (timeLimit >= 0))
        {
            // Set seconds for contdown which is rounded up previous cleartime
            timeLimit += Mathf.Ceil(clearTimeAtLevel);
            // Level+1
            level++;
            // 
            isStartingNextLevel = true;
            clearTimeAtLevel = 0 ;

            ResetEnemyGroups();

            GameSceneCanvas();
        }
    }

    public void GameSceneCanvas()
    {
        if (level >= 2) 
        {
            gameTextCanvas.SetActive(true);
            /* Not use but just for check
            levelText.text = "Level : " + level.ToString();
            defeatedEnemiesText.text = "Enemies defeated : " + totalDefeatedEnemy.ToString();
            */
            timeLimitText.text = "TimeLimit : " + timeLimit.ToString();

            StartCountDown();
        }
    }

    public void ShowGameOverCanvas() 
    {
        gameOverCanvas.SetActive(true);
        startGameCanvas.SetActive(false);
        gameScreen.SetActive(false);

        defeatedEnemiesTextInGameOverCanvas.text = totalDefeatedEnemy.ToString();
        LevelTextInGameOverCanvas.text = level.ToString();

        /*if (timeLimit < 0)
        {
            
        }*/
    }

    public void PlayAgain()
    {
        ShowStartGameCanvas();
    }

    public void ShowStartGameCanvas()
    {
        startGameCanvas.SetActive(true);
        gameScreen.SetActive(false);
        gameOverCanvas.SetActive(false);

    }

    public void Play()
    {
        gameScreen.SetActive(true);
        startGameCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    public void ResetEnemyGroups() 
    {
        Instantiate(enemyGroupPrefab, enemies.transform.position, Quaternion.identity);
        Instantiate(enemyGroup2Prefab, enemies.transform.position, Quaternion.identity);
        Instantiate(enemyGroup3Prefab, enemies.transform.position, Quaternion.identity);
    }


}
