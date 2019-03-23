using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    private bool hasKey = false;
    private bool shouldOpen = true;

    public GameObject key;
    public GameObject door;
    public GameObject keyImage;
    public GameObject gateRight;
    public GameObject gateLeft;

    private float ogLX = 353.7131f;
    private float ogLY = 5.997021f;
    private float ogLZ = -35.04168f;

    private float ogRX = 353.7131f;
    private float ogRY = 5.997021f;
    private float ogRZ = -35.04168f;


    float leftNewX = 351.28f;
    float leftNewY = 5.997021f;
    float leftNewZ = -35.04168f;

    float rightNewX = 356.28f;
    float rightNewY = 5.997021f;
    float rightNewZ = -35.04168f;

    public Transform leftTransform;
    public Transform rightTransform;

    // Use this for initialization
    void Start () {
        leftTransform = gateLeft.GetComponent<Transform>();
        rightTransform = gateRight.GetComponent<Transform>();
        keyImage.SetActive(false);
        PlayerPrefs.SetInt("Coins",0);
        key.SetActive(false);
        door.SetActive(false);
}
	
	// Update is called once per frame
	void Update ()
    {

        if (!hasKey)
        {
            if (PlayerPrefs.GetInt("Coins") >= 10 && GamePlay.currentLevel == 0)
            {
                key.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Coins") >= 40 && GamePlay.currentLevel == 1)
            {
                key.SetActive(true);
            }

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "key")
        {
            keyImage.SetActive(true);
            hasKey = true;
            key.SetActive(false);
            door.SetActive(true);
        }

        if (col.gameObject.name == "Gate")
        {
            if(hasKey)
            {
                StartCoroutine(openLeftGate());
                StartCoroutine(openRightGate());
            }
        }

        if (col.gameObject.name == "GateR")
        {
            if (hasKey && PlayerPrefs.GetInt("Coins") >= 10 && GamePlay.currentLevel == 0)
            {
                StartCoroutine(closeLeftGate());
                StartCoroutine(closeRightGate());
                hasKey = false;
                keyImage.SetActive(false);
                UIManager.NextLevel();
            }
            if (hasKey && PlayerPrefs.GetInt("Coins") >= 40 && GamePlay.currentLevel == 1)
            {
                StartCoroutine(closeLeftGate());
                StartCoroutine(closeRightGate());
                hasKey = false;
                keyImage.SetActive(false);
                UIManager.NextLevel();

            }
        }
    }
    IEnumerator openLeftGate()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            gateLeft.transform.position = Vector3.Lerp(gateLeft.transform.position, new Vector3(leftNewX, leftNewY, leftNewZ), timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (gateLeft.transform.position == new Vector3(leftNewX, leftNewY, leftNewZ))
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }

    private IEnumerator openRightGate()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            gateRight.transform.position = Vector3.Lerp(gateRight.transform.position, new Vector3(rightNewX, rightNewY, rightNewZ), timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (gateRight.transform.position == new Vector3(rightNewX, rightNewY, rightNewZ))
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }


    private IEnumerator closeRightGate()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            gateRight.transform.position = Vector3.Lerp(gateRight.transform.position, new Vector3(ogRX, ogRY, ogRZ), timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (gateRight.transform.position == new Vector3(ogRX, ogRY, ogRZ))
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }

    private IEnumerator closeLeftGate()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            gateLeft.transform.position = Vector3.Lerp(gateRight.transform.position, new Vector3(ogRX, ogRY, ogRZ), timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (gateLeft.transform.position == new Vector3(ogRX, ogRY, ogRZ))
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }

}
