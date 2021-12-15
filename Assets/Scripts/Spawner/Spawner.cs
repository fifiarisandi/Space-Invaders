using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    // Public variables
    public GameObject[] waves;
    public GameObject winingScreen; 

    public Text waveNumberUI;
    public Text enemyCounterUI;

    public int currentEnemies;

    // Private variables 
    private int currentWaveNumber; 
    private Vector3 spawnPosition; 

 
    // Start is called before the first frame update
    void Start()
    {
        // Sets the waves UI in the beginning of the game.    
        waveNumberUI.text = "Wave " + (currentWaveNumber + 1) + "/5";

        currentWaveNumber = 0; 

        // Sets the position of the spawner. 
        spawnPosition = new Vector3(0, 3.5f, 0);

        // Spawns first wave of enemies. 
        SpawnWave();
    }

    // Spawns a wave and saves enemy number of wave. 
    private void SpawnWave()
    {
        // Spawns wave from the waves array and saves wave in currentWave variable. 
        GameObject currentWave = Instantiate(waves[currentWaveNumber], spawnPosition, Quaternion.identity);

        // Uses wave variable to set spawner refernce in enemy controller and saves returned enemy number of wave. 
        currentEnemies = currentWave.GetComponent<EnemyController>().SetSpawnerReference(this);

        // Sets the enemies UI in the beginning of the wave.
        enemyCounterUI.text = "Enemies: " + currentEnemies;
    }


    // Reduces Enemy count number and spawns new wave if all enemies are dead. 
    public void ReduceEnemies ()
    {
        // Reduces enemy number in variable.
        currentEnemies--;

        // Updates the enemies UI in the game. 
        enemyCounterUI.text = "Enemies: " + currentEnemies;

        // Checks if all enemies of the wave are dead.
        if (currentEnemies <=0)
        {

            // Checks if it was the last wave.
            // If not, the currentWaveNumber increases and RecoverTime gets called.
            if (currentWaveNumber < waves.Length-1) 
            {
                currentWaveNumber++;
                StartCoroutine(RecoverTime());
            } 

            // If it was the last wave the winningScreen is set to active. 
            else 
            {
               winingScreen.SetActive(true);
            }
        }
    }

    // Sets a three second recover time and then spawns a new wave starts. 
    private IEnumerator RecoverTime ()
    {
        // Everything after yield return has to wait for three seconds.
        yield return new WaitForSeconds(3);

        // Destroys all player projectiles, so that they won't instantly hit the new wave.  
        DestroyProjectiles();

        // Spwans a new wave.
        SpawnWave();

        // Updates the wave UI in the game. 
        waveNumberUI.text = "Wave " + (currentWaveNumber + 1) + "/5";
    }

    //Destroys all GameObjects with the tag Projectile. 
    private void DestroyProjectiles()
    {
        // Creates an array with all the player projectiles. 
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");

        // Destroys every projectile by going through the array. 
        foreach (GameObject projectile in projectiles)
        {
            GameObject.Destroy(projectile);
        }
    }
}
