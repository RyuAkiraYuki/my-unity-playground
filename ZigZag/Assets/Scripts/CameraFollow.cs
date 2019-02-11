using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ball;
    Vector3 vOffset;

    public float lerpRate;

    public bool isGameOver;

    // Use this for initialization
    void Start() {
        vOffset = ball.transform.position - transform.position;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if (!isGameOver) {
            Follow();
        }
    }

    void Follow() {
        Vector3 curPos = transform.position;
        Vector3 targetPos = ball.transform.position - vOffset;
        curPos = Vector3.Lerp(curPos, targetPos, lerpRate * Time.deltaTime);
        transform.position = curPos;
    }
}
