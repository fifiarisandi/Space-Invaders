using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script allows seeing score which is changing during the game
public class Score : MonoBehaviour
{

    public static int scoreValue = 0;
    Text score;

    
    void Start()
    {
        score = GetComponent<Text>();
    }

   
    void Update()
    {
        score.text = "Score:" + scoreValue;
    }
}
