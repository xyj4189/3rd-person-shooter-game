using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 10);
            UIManager.Instance.UpdateSc();
            Destroy(this.gameObject);
        }
    }
}
