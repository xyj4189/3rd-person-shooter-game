 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float damping;

    Transform cameraLookTarget;
    GameObject player;


    // Use this for initialization
    void Awake () {
        player = GameObject.Find("Player");
        cameraLookTarget = player.transform.Find("cameraLookTarget");

    }

    void Start()
    {
        player = GameObject.Find("Player");
        cameraLookTarget = player.transform.Find("cameraLookTarget");

    }
	
	// Update is called once per frame
	void Update () {
       
        Vector3 targetPosition = cameraLookTarget.position + player.transform.forward * cameraOffset.z +
            player.transform.up * cameraOffset.y +
            player.transform.right * cameraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);//substracting the position 


        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
    }
}
