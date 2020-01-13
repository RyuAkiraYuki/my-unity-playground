using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameManager theGM;

    public Rigidbody theRB;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 curPos = transform.position;
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (moveSpeed * Time.deltaTime));
    }

    public void OnTriggerEnter(Collider other) {

        if (other.tag == "Hazards") {
            Debug.Log("Hit a hazard!");

            theGM.HitHazard();

            theRB.isKinematic = false;

            theRB.velocity = new Vector3(Random.Range(GameManager._objSpeed / 2f, -GameManager._objSpeed / 2f), 2.5f, -(GameManager._objSpeed/2f));
        }

    }
}
