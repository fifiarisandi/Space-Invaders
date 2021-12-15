using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Public variables
    public GameObject creditScreen; 


    // Loads the StartScreen Scene to get to the main menu.
    public void GetToMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    // Loads the SpaceInvaders Scene which contains and starts the game. 
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Opens the credits by setting the Credits panel active. 
    public void OpenCredit()
    {
        creditScreen.SetActive(true);
    }

    // Closes the credits by setting the Credits panel inactive. 
    public void CloseCredit()
    {
        creditScreen.SetActive(false);
    }
}