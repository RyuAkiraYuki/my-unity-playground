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

    private Vector3 startPosition;
    private Quaternion startRotation;

    public float invincibleTime;
    private float invincibleTimer;

    // Start is called before the first frame update
    void Start() {
        startPosition = transform.position;
        startRotation = transform.rotation;
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

        //control invincibility
        if(invincibleTimer > 0) {
            invincibleTimer -= Time.deltaTime;
        }

        //animations transitioning
        anim.SetBool("isWalking", theGM.canMove);
        anim.SetBool("onGround", onGround);
    }

    public void OnTriggerEnter(Collider other) {

        if (other.tag == "Hazards") {

            if(invincibleTimer <= 0) {
                Debug.Log("Hit a hazard!");

                theGM.HitHazard();

                //theRB.isKinematic = false;

                theRB.constraints = RigidbodyConstraints.None;

                theRB.velocity = new Vector3(Random.Range(GameManager._objSpeed / 2f, -GameManager._objSpeed / 2f), 2.5f, -GameManager._objSpeed / 2f);
            }
            
        }

        if(other.tag == "Coins") {
            theGM.AddCoin();
            Destroy(other.gameObject);
        }

    }

    public void ResetPlayer() {
        theRB.constraints = RigidbodyConstraints.FreezeRotation;
        transform.rotation = startRotation;
        transform.position = startPosition;

        invincibleTimer = invincibleTime;
    }
}
