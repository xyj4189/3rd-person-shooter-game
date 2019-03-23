using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    private int health;
    private int kills;
    private int coins;

    private bool isAlive;



    public static PlayerInfo Instance;


	// Use this for initialization
	void Start () {
        Instance = this;
        health = 10;
        kills = 0;
        coins = 0;
        isAlive = true;
        UIManager.Instance.UpdateHealth(health);
        UIManager.Instance.UpdateKills(kills);
        UIManager.Instance.UpdateCoins(coins);
        //DontDestroyOnLoad(gameObject);
    }
	
	public void Hurt(int damage)
    {if(health >= 1)
        health -= damage;
        //Debug.Log("Player Health - " + health);
        UIManager.Instance.UpdateHealth(health);
        if (health==0)
        {
            isAlive = false;
            UIManager.Instance.GameOver();
        }
        else if(health < 0)
        {
            return;
        }
    }

    public bool getPlayerAlive()
    {
        return isAlive;
    }

    public void killedZombie(int val)
    {
        //Debug.Log("killed");
        kills++;
        Debug.Log(coins);
        coins += val;
        Debug.Log(coins);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
        UIManager.Instance.UpdateCoins(coins);
        UIManager.Instance.UpdateKills(kills);
        if(kills == UIManager.Instance.totalEnemies)
        {
            StartCoroutine(Wait());
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.LevelComplete();
    }
    public int getCoins()
    {
        return coins;
    }
}
