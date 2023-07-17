using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public static levelLoader instance;
    private int currentLevel;
    private int maxLevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        maxLevel = 5;
        DontDestroyOnLoad(this.gameObject);
        GetLevel();
    }
    
    

    public void GetLevel()
    {
        currentLevel = PlayerPrefs.GetInt("keyLevel", 1);
        LoadLevel();
    }

    private void LoadLevel()
    {
        string levelName = "LevelScene" + currentLevel;
        SceneManager.LoadScene(levelName);
    }

    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel > maxLevel)
        {
            currentLevel = 1;
        }
        PlayerPrefs.SetInt("keyLevel", currentLevel);
        LoadLevel();
    }
}
