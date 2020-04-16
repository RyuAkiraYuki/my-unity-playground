using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MMenu : MonoBehaviour {

    public string targetScene;

    // Main screen elements
    public GameObject mainScreen;

    // Switch screen elements
    public GameObject charSwitchScreen;
    public GameObject useThisCharacterButton;
    public GameObject unawailableIconButton;
    public GameObject getCoinsButton;
    public GameObject unlockCharacterButton;
    public Text coinsCountTxt;
    private int currentCharacterPrice;


    public Transform theCamera;
    public Transform charSwitchHolder;

    private Vector3 camTargetPos;
    public float camSpeed;


    public GameObject[] theCharacters;
    public int currenChar;

    public int coinsCount;


    // Start is called before the first frame update
    void Start() {
        camTargetPos = theCamera.position;

        if (!PlayerPrefs.HasKey(theCharacters[0].name)) {
            PlayerPrefs.SetInt(theCharacters[0].name, 1);
        }

        PlayerPrefs.SetInt(theCharacters[0].name, 1);

        if (PlayerPrefs.HasKey("CoinsCollected")) {
            coinsCount = PlayerPrefs.GetInt("CoinsCollected");
        } else {
            PlayerPrefs.SetInt("CoinsCollected", 0);
            coinsCount = 0;
        }

        coinsCountTxt.text = "Coins: " + coinsCount;
        currentCharacterPrice = theCharacters[currenChar].GetComponent<CharacterOptions>().getCharacterPrice();
    }

    // Update is called once per frame
    void Update() {
        theCamera.position = Vector3.Lerp(theCamera.position, camTargetPos, camSpeed * Time.deltaTime);
        coinsCountTxt.text = "Coins: " + coinsCount;
    }

    public void PlayGeme() {
        SceneManager.LoadScene(targetScene);
    }

    public void ChooseChar() {
        mainScreen.SetActive(false);
        charSwitchScreen.SetActive(true);

        camTargetPos = theCamera.position + new Vector3(0f, charSwitchHolder.position.y, 0f);

        UnlockCheck();
    }

    public void moveRight() {
        int maxCharacters = theCharacters.Length - 1;
        if (currenChar < maxCharacters) {
            camTargetPos += new Vector3(-2f, 0f, 0f);

            currenChar++;
        } else {

            camTargetPos += new Vector3((2f * maxCharacters), 0f, 0f);

            currenChar = 0;
        }

        setCharacterPriceOnButton();
        UnlockCheck();

    }

    public void moveLeft() {
        int maxCharacters = theCharacters.Length - 1;
        if (currenChar > 0) {

            camTargetPos += new Vector3(2f, 0f, 0f);

            currenChar--;
        } else {
            camTargetPos += new Vector3((-2f * maxCharacters), 0f, 0f);

            currenChar = maxCharacters;
        }

        setCharacterPriceOnButton();
        UnlockCheck();

    }

    private void setCharacterPriceOnButton() {
        //unlockCharacterBtnText.text = "Unlock character for " + theCharacters[currenChar].GetComponent<CharacterOptions>().getCharacterPrice() + " coins";
        currentCharacterPrice = theCharacters[currenChar].GetComponent<CharacterOptions>().getCharacterPrice();
        unlockCharacterButton.GetComponentInChildren<Text>().text = "Unlock character for " + currentCharacterPrice + " coins";
        getCoinsButton.GetComponentInChildren<Text>().text = currentCharacterPrice + " coins needed to unlock! Tap to get more!";
    }


    public void UnlockCheck() {
        if (PlayerPrefs.HasKey(theCharacters[currenChar].name)) {

            if (PlayerPrefs.GetInt(theCharacters[currenChar].name) == 0) {
                //The logic fpr the case that current character is not awailable for play
                useThisCharacterButton.SetActive(false);
                unawailableIconButton.SetActive(true);
                if (coinsCount < currentCharacterPrice) {
                    getCoinsButton.SetActive(true);

                    unlockCharacterButton.SetActive(false);
                } else {
                    unlockCharacterButton.SetActive(true);

                    getCoinsButton.SetActive(false);
                }
            } else {

                // Goes the logic for the case that current character is awailable for play
                useThisCharacterButton.SetActive(true);
                unlockCharacterButton.SetActive(false);
                getCoinsButton.SetActive(false);
                unawailableIconButton.SetActive(false);
            }

        } else {
            PlayerPrefs.SetInt(theCharacters[currenChar].name, 0);
            UnlockCheck();
        }
    }

    public void UnlockCharacter() {
        coinsCount -= currentCharacterPrice;

        PlayerPrefs.SetInt(theCharacters[currenChar].name, 1);
        PlayerPrefs.SetInt("CoinsCollected", coinsCount);

        UnlockCheck();
    }


    public void PlayUsingCurrentCharacter() {
        PlayerPrefs.SetString("SelectedCharacter", theCharacters[currenChar].name);

        PlayGeme();
    }


    public void ResetCharacters() {
        for (int i = 1; i < theCharacters.Length; i++) {
            PlayerPrefs.SetInt(theCharacters[i].name, 0);
        }

        UnlockCheck();
    }

    public void placeObjectsInCircle(GameObject[] objects, Vector3 location) {
        for (int i = 0; i < objects.Length; i++) {
            float radius = objects.Length;
            float angle = i * Mathf.PI * 2f / radius;
            Vector3 newPos = transform.position + (new Vector3(Mathf.Cos(angle) * radius, -2, Mathf.Sin(angle) * radius));
            objects[i].transform.position = newPos;
        }
    }

    public void instantiateInCircle(GameObject obj, Vector3 location, int howMany) {
        for (int i = 0; i < howMany; i++) {
            float radius = howMany;
            float angle = i * Mathf.PI * 2f / radius;
            Vector3 newPos = transform.position + (new Vector3(Mathf.Cos(angle) * radius, -2, Mathf.Sin(angle) * radius));
            Instantiate(obj, newPos, Quaternion.Euler(0, 0, 0));
        }
    }
}
