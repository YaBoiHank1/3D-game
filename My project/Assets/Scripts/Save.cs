using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    private void Start()
    {
        
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("playerX", player.transform.position.x);
        PlayerPrefs.SetFloat("playerY", player.transform.position.y);
        PlayerPrefs.SetFloat("playerZ", player.transform.position.z);

        PlayerPrefs.SetFloat("enemyX", enemy.transform.position.x);
        PlayerPrefs.SetFloat("enemyY", enemy.transform.position.y);
        PlayerPrefs.SetFloat("enemyZ", enemy.transform.position.z);

        PlayerPrefs.SetInt("collected", FindObjectOfType<ObjectiveTracker>().collected);
    }

    public void LoadGame()
    {
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("playerX"), PlayerPrefs.GetFloat("playerY"), PlayerPrefs.GetFloat("playerZ"));

        enemy.transform.position = new Vector3(PlayerPrefs.GetFloat("enemyX"), PlayerPrefs.GetFloat("enemyY"), PlayerPrefs.GetFloat("enemyZ"));

        FindObjectOfType<ObjectiveTracker>().collected = PlayerPrefs.GetInt("collected");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveGame();
        }
        if(Input.GetKeyDown(KeyCode.F9))
        {
            LoadGame();
        }
    }
}
