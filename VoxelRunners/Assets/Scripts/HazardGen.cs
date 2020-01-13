using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGen : MonoBehaviour {

    public GameObject[] hazards;

    public float timeBetweenHazards;

    private float hazardGenCounter;
    // Start is called before the first frame update
    void Start() {
        hazardGenCounter = timeBetweenHazards;
    }

    // Update is called once per frame
    void Update() {

        if (GameManager._canMove) {
            hazardGenCounter -= Time.deltaTime;

            if (hazardGenCounter <= 0) {

                int chosenHazard = Random.Range(0, hazards.Length);
                Instantiate(hazards[chosenHazard], transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, Random.Range(-45f, 45f), transform.rotation.eulerAngles.z));

                hazardGenCounter = Random.Range(timeBetweenHazards * 0.25f, timeBetweenHazards * 1.75f);//timeBetweenHazards;
            }
        }

    }
}
