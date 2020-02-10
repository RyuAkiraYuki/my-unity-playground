using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool canMove;
    static public bool _canMove;

    public float objSpeed;
    static public float _objSpeed;

    public int coinsCount;

    private bool coinHitThisFrame;
    private bool gameStarted;



    //speeding up

    public float timeToIncSpeed;
    private float incSpeedCounter;
    public float speedMultiplier;
    private float targetSpeedMuitiplier;
    public float acceleration;
    private float accelerationStore;
    public float speedIncAmount;
    private float worldSpeedStore;


    // Start is called before the first frame update
    void Start() {
        if (PlayerPrefs.HasKey("CoinsCollected")) {
            coinsCount = PlayerPrefs.GetInt("CoinsCollected");
        }

        incSpeedCounter = timeToIncSpeed;
        targetSpeedMuitiplier = speedMultiplier;
        worldSpeedStore = objSpeed;
        accelerationStore = acceleration;
    }

    // Update is called once per frame
    void Update() {
        _canMove = canMove;
        _objSpeed = objSpeed;


        if (!gameStarted && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))) {
            canMove = true;
            _canMove = true;

            gameStarted = true;
        }

        if (canMove) {
            incSpeedCounter -= Time.deltaTime;
            if (incSpeedCounter <= 0) {
                incSpeedCounter = timeToIncSpeed;

                //objSpeed = objSpeed * speedMultiplier;

                targetSpeedMuitiplier = targetSpeedMuitiplier * speedIncAmount;

                timeToIncSpeed = timeToIncSpeed * 0.97f;
            }

            speedMultiplier = Mathf.MoveTowards(speedMultiplier, targetSpeedMuitiplier, acceleration * Time.deltaTime);
            acceleration = accelerationStore * speedMultiplier;
            objSpeed = worldSpeedStore * speedMultiplier;
        }

        coinHitThisFrame = false;
    }


    public void HitHazard() {
        canMove = false;
        _canMove = false;

        PlayerPrefs.SetInt("CoinsCollected", coinsCount);
    }

    public void AddCoin() {
        if (!coinHitThisFrame) {
            coinsCount++;
            coinHitThisFrame = true;
        }

    }
}
