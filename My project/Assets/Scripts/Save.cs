using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public QuestObjective gasCan1;
    public QuestObjective gasCan2;
    public QuestObjective gasCan3;
    public QuestObjective gasCan4;
    public QuestObjective gasCan5;

    private void Start()
    {
        gasCan1 = GetComponent<QuestObjective>();
        gasCan2 = GetComponent<QuestObjective>();
        gasCan3 = GetComponent<QuestObjective>();
        gasCan4 = GetComponent<QuestObjective>();
        gasCan5 = GetComponent<QuestObjective>();
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

        PlayerPrefs.SetInt("active1", gasCan1.on);
        PlayerPrefs.SetInt("active2", gasCan2.on);
        PlayerPrefs.SetInt("active3", gasCan3.on);
        PlayerPrefs.SetInt("active4", gasCan4.on);
        PlayerPrefs.SetInt("active5", gasCan5.on);
    }

    public void LoadGame()
    {
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("playerX"), PlayerPrefs.GetFloat("playerY"), PlayerPrefs.GetFloat("playerZ"));

        enemy.transform.position = new Vector3(PlayerPrefs.GetFloat("enemyX"), PlayerPrefs.GetFloat("enemyY"), PlayerPrefs.GetFloat("enemyZ"));

        FindObjectOfType<ObjectiveTracker>().collected = PlayerPrefs.GetInt("collected");

        gasCan1.on = PlayerPrefs.GetInt("active1");
        gasCan2.on = PlayerPrefs.GetInt("active2");
        gasCan3.on = PlayerPrefs.GetInt("active3");
        gasCan4.on = PlayerPrefs.GetInt("active4");
        gasCan5.on = PlayerPrefs.GetInt("active5");
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
