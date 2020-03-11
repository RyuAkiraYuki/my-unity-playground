using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public bool canMove;
    static public bool _canMove;

    public float objSpeed;
    static public float _objSpeed;

    public int coinsCount;
    private float distanceCovered;

    private bool coinHitThisFrame;
    private bool gameStarted;
    public string mainMenuName;
    public PlayerController thePlayer;



    //speeding up

    public float timeToIncSpeed;
    private float incSpeedCounter;
    public float speedMultiplier;
    private float targetSpeedMuitiplier;
    public float acceleration;
    private float accelerationStore;
    public float speedIncAmount;
    private float worldSpeedStore;

    //ui-text controll
    public GameObject tapMessage;
    public Text coinsText;
    public Text distanceText;


    //game stuck panel 
    public GameObject stuckScreen;
    public Text stuckScreenCoins;
    public Text stuckScreenDistance;
    public float stuckScreenDelay;
    

    //coins prompt panel 
    public GameObject coinPromptPanel;


    // Start is called before the first frame update
    void Start() {
        if (PlayerPrefs.HasKey("CoinsCollected")) {
            coinsCount = PlayerPrefs.GetInt("CoinsCollected");
        }
        if (PlayerPrefs.HasKey("DistanceCovered")) {
            distanceCovered = PlayerPrefs.GetFloat("DistanceCovered");
        }

        incSpeedCounter = timeToIncSpeed;
        targetSpeedMuitiplier = speedMultiplier;
        worldSpeedStore = objSpeed;
        accelerationStore = acceleration;
        //UI
        coinsText.text = "Coins: " + coinsCount;
        distanceText.text = "Distance: " + Mathf.Floor(distanceCovered) + "m";
    }

    // Update is called once per frame
    void Update() {
        _canMove = canMove;
        _objSpeed = objSpeed;


        if (!gameStarted && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))) {
            canMove = true;
            _canMove = true;

            gameStarted = true;

            tapMessage.SetActive(false);
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

            //updating UI
            distanceCovered += Time.deltaTime * worldSpeedStore;
            distanceText.text = "Distance: " + Mathf.Floor(distanceCovered) + "m";
        }




        coinHitThisFrame = false;
    }


    public void HitHazard() {
        canMove = false;
        _canMove = false;

        PlayerPrefs.SetInt("CoinsCollected", coinsCount);

        //stuckScreen.SetActive(true);
        stuckScreenCoins.text = coinsCount + " coins!";
        stuckScreenDistance.text = Mathf.Floor(distanceCovered) + "m";

        StartCoroutine("ShowStuckScreen");
    }


    public IEnumerator ShowStuckScreen() {
        yield return new WaitForSeconds(stuckScreenDelay);
        stuckScreen.SetActive(true);
    }

    public void AddCoin() {
        if (!coinHitThisFrame) {
            coinsCount++;
            coinHitThisFrame = true;

            coinsText.text = "Coins: " + coinsCount;
        }

    }

    public void ContinueGame() {
        if(coinsCount < 100) {
            coinPromptPanel.SetActive(true);
        } else {
            coinsCount -= 100;
            //PlayerPrefs.SetInt("CoinsCollected", coinsCount);

            canMove = true;
            _canMove = true;

            thePlayer.ResetPlayer();


            stuckScreen.SetActive(false);
        }
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    public void MainMenu() {
        SceneManager.LoadScene(mainMenuName);
    }

    public void GetCoins() {

    }

    public void CloseCoinPrompt() {
        coinPromptPanel.SetActive(false);
    }
}
