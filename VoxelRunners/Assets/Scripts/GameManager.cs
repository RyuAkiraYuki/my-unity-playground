﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool canMove;
    static public bool _canMove;

    public float objSpeed;
    static public float _objSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _canMove = canMove;
        _objSpeed = objSpeed;
    }
}
