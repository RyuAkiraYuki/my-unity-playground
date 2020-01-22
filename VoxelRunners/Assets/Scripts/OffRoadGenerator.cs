using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffRoadGenerator : MonoBehaviour {

    public float timeBetweenObjects;
    private float objGenCounter;

    public GameObject[] sideObjects;


    public Transform minPoint;
    public Transform maxPoint;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (GameManager._canMove) {
            objGenCounter -= Time.deltaTime;

            if (objGenCounter <= 0) {

                int chosenObj = Random.Range(0, sideObjects.Length);

                //getting new random point

                Vector3 getPoint = new Vector3(Random.Range(minPoint.position.x,maxPoint.position.x),transform.position.y,transform.position.z);

                Instantiate(sideObjects[chosenObj], getPoint, Quaternion.Euler(transform.rotation.eulerAngles.x, Random.Range(-45f, 45f), transform.rotation.eulerAngles.z));

                objGenCounter = Random.Range(timeBetweenObjects * 0.25f, timeBetweenObjects * 1.75f);//timeBetweenHazards;
            }
        }
    }
}
