using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameManager theGM;

    public Rigidbody theRB;

    public float jumpForce;

    public Transform mdlHolder;
    public LayerMask whatIsGround;
    public bool onGround;

    public Animator anim;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (theGM.canMove) {

            onGround = Physics.OverlapSphere(mdlHolder.position,0.2f,whatIsGround).Length > 0;

            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && onGround) {
                //make player jump
                theRB.velocity = new Vector3(0f, jumpForce, 0f);
            }
        }


        //animations transitioning
        anim.SetBool("isWalking", theGM.canMove);
        anim.SetBool("onGround", onGround);
    }

    public void OnTriggerEnter(Collider other) {

        if (other.tag == "Hazards") {
            Debug.Log("Hit a hazard!");

            theGM.HitHazard();

            //theRB.isKinematic = false;

            theRB.constraints = RigidbodyConstraints.None;

            theRB.velocity = new Vector3(Random.Range(GameManager._objSpeed / 2f, -GameManager._objSpeed / 2f), 2.5f, -GameManager._objSpeed / 2f);
        }

    }
}
