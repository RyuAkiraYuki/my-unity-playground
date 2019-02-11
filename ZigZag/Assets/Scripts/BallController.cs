using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField]
    private float speed;
    Rigidbody rigBdy;

    bool isStarted;
    bool isGameOver;


    void Awake() {
        rigBdy = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start() {
        isStarted = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if (!isStarted) {
            if (Input.GetMouseButtonDown(0)) {
                rigBdy.velocity = new Vector3(speed, 0, 0);
                isStarted = true;
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) {
            isGameOver = true;
            rigBdy.velocity = new Vector3(0, -speed * 3, 0);

            Camera.main.GetComponent<CameraFollow>().isGameOver = true;
        }

        if (Input.GetMouseButtonDown(0) && !isGameOver) {
            SwitchDirection();
        }
    }

    void SwitchDirection() {
        if (rigBdy.velocity.z > 0) {
            rigBdy.velocity = new Vector3(speed, 0, 0);
        } else if (rigBdy.velocity.x > 0) {
            rigBdy.velocity = new Vector3(0, 0, speed);
        }
    }
}
