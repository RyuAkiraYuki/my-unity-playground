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

    // Start is called before the first frame update
    void Start() {

        coinsCount = PlayerPrefs.GetInt("CoinsCollected");

    }

    // Update is called once per frame
    void Update() {
        _canMove = canMove;
        _objSpeed = objSpeed;

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
