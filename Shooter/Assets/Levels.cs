using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour {

    public GameObject[]  Level;
	// Use this for initialization
	void Start () {
        int levelvalue;
     //   PlayerPrefs.GetInt("Level", 0);
    }

    public void level1()
    {
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene("GamePlay");
    }
    public void level2()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("GamePlay2");
    }
    public void level3()
    {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene("GamePlay3");
    }
}
