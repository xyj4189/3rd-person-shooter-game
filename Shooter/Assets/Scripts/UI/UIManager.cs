using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public int coins4NL;
    public Text healthText, killsText, playerDiedText, coinsText;

    public static UIManager Instance;

    public Transform gamePlayer;

    public GameObject nextPanel, replayBtn, panel,msg;

    public int totalEnemies;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        gamePlayer = GameObject.Find("Player").transform;
        UIManager.Instance.coinsText.text = "Coins : " + PlayerPrefs.GetInt("Coins");
    }

    public void UpdateHealth(int health)
    {
        UIManager.Instance.healthText.text = "Health : " + health;
        
    }

    public void UpdateKills(int kills)
    {
        UIManager.Instance.killsText.text = "Kills : " + kills;
    }

    public void UpdateCoins(int coins)
    {
        Debug.Log("updating coins");
        UIManager.Instance.coinsText.text = "Coins : " + PlayerPrefs.GetInt("Coins");
    }
    public void UpdateSc ()
    {
        UIManager.Instance.coinsText.text = "Coins : " + PlayerPrefs.GetInt("Coins");
    }
    public void GameOver()
    {
        playerDiedText.gameObject.SetActive(true);

    }

    public void LevelComplete()
    {

        // GamePlay.currentLevel++;
        // panel.SetActive(true);
        if (PlayerPrefs.GetInt("Coins") >= coins4NL)
        {
            // msg.SetActive(false);
            //  nextPanel.SetActive(true);
            //  replayBtn.gameObject.SetActive(false);
        }
        else
        {
            // nextPanel.SetActive(false);
            //  msg.SetActive(true);
            //  replayBtn.gameObject.SetActive(true);
        }
    }

    public Transform getPlayer()
    {
        return gamePlayer;
    }

    public static void NextLevel()
    {
        GamePlay._instance.EnableNextLevel();
        //SceneManager.LoadSceneAsync(1);
    }

    public void Replay ()
    {
        SceneManager.LoadScene("GamePlay");
        GamePlay.currentLevel = 0;
        //SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ReturnMainLobby()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
