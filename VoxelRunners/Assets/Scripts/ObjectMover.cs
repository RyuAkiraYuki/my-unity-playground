using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._canMove) {
            transform.position -= new Vector3(0f, 0f, GameManager._objSpeed * Time.deltaTime);
        }        

        if (transform.position.z < PathDetruction.zPosition) {
            Destroy(gameObject);
        }
    }
}
