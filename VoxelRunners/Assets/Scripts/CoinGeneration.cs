﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour {

    public float timeBetweenCoins;

    private float coinGenCounter;

    public GameObject[] coinGroups;

    public Transform topPos;

    // Start is called before the first frame update
    void Start() {
        coinGenCounter = timeBetweenCoins;
    }

    // Update is called once per frame
    void Update() {
        if (GameManager._canMove) {
            coinGenCounter -= Time.deltaTime;

            if (coinGenCounter <= 0) {

                bool goTop = Random.value > .5f;

                int chosenHazard = Random.Range(0, coinGroups.Length);

                if (goTop) {
                    Instantiate(coinGroups[chosenHazard], topPos.position, transform.rotation);
                } else {
                    Instantiate(coinGroups[chosenHazard], transform.position, transform.rotation);
                }



                coinGenCounter = Random.Range(timeBetweenCoins * 0.5f, timeBetweenCoins * 1.5f);//timeBetweenHazards;
            }
        }
    }
}
