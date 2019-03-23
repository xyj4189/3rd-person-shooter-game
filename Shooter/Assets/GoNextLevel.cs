using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoNextLevel : MonoBehaviour {

    public GameObject nextlevelpanel;
	// Use this for initialization
	void Start () {
        PlayerPrefs.GetInt("Coins");
        nextlevelpanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nextlevelpanel.SetActive(true);
            PlayerPrefs.SetInt("Coins", 10);
            unlock();
            Time.timeScale = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nextlevelpanel.SetActive(false);
        }

    }

    
    void unlock() {

        int levelvalue;
        levelvalue = PlayerPrefs.GetInt("Level", 0);
        if (levelvalue == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        if (levelvalue == 1)
        {
            PlayerPrefs.SetInt("Level", 2);
        }
        if (levelvalue == 2)
        {
            PlayerPrefs.SetInt("Level", 3);
        }
    }

}
