using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private int modeNo;
    public GameObject raccoonMode;
    public GameObject birdMode;
    private GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        modeNo = 0;
        player = raccoonMode;
        offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetKeyUp("1")) {
            if (modeNo == 0) {
                modeNo = 1;
                player = birdMode;
            } else if (modeNo == 1) {
                modeNo = 0;
                player = raccoonMode;
            }
        }
        transform.position = player.transform.position + offset;
	}
}