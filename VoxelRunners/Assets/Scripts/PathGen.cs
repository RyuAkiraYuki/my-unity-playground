using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGen : MonoBehaviour
{
    //public GameObject pathBlock;

    public GameObject[] pathBlocks;

    public Transform thresholdPoint;

    public float generationStepSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < thresholdPoint.position.z) {
            // Copy the block and movefurther
            //Instantiate(pathBlock, transform.position, transform.rotation);
            //transform.position += new Vector3(0f, 0f, 1.6f);

            // Pick a random tile from available
            int tileNum = Random.Range(0,pathBlocks.Length);
            Instantiate(pathBlocks[tileNum], transform.position, transform.rotation);
            transform.position += new Vector3(0f, 0f, generationStepSize);
        }

    }
}
