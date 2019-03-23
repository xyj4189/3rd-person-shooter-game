using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    public Text coins;
	// Use this for initialization
	void Start () {

        coins.text = "Coins: "+ PlayerPrefs.GetInt("Coins").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Play()
    {
        Application.LoadLevel(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void levels()
    {
        SceneManager.LoadScene("MainMen1");
    }
}
