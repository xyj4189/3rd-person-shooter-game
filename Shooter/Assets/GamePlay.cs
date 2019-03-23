using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour {
    public static GamePlay _instance;
    public static int currentLevel=0;
    public GameObject[] Levels;
    int levelvalue;
    // Use this for initialization
    void Start ()
    {
      //  PlayerPrefs.DeleteAll();
        Time.timeScale = 1;
        _instance = this;
        Levels[0].gameObject.SetActive(true);
        spawnlevel();
       
        levelvalue = PlayerPrefs.GetInt("Level", 0);
    }

    void spawnlevel()
    {

        //int levelvalue;
        //levelvalue = PlayerPrefs.GetInt("Level", 0);
        Debug.Log("level" +levelvalue);
        foreach (GameObject item in Levels)
        {
            item.SetActive(false);
        }

        Levels[levelvalue].SetActive(true);
    }


    public void NextLevel()
    {
        //int levelvalue;
        //levelvalue = PlayerPrefs.GetInt("Level", 0);
        Debug.Log("levellll"+levelvalue);

        if (levelvalue == 0)
        {
            SceneManager.LoadScene("GamePlay2");
        }
        if (levelvalue == 1)
        {
            SceneManager.LoadScene("GamePlay3");
        }

    }
    public void EnableNextLevel ()
    {
        Levels[currentLevel].gameObject.SetActive(false);
        currentLevel++;
        Levels[currentLevel].gameObject.SetActive(true);
    }
}
