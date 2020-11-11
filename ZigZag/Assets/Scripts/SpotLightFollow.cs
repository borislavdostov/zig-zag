﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightFollow : MonoBehaviour
{
    public static SpotLightFollow instance;

    public GameObject ball;
    Vector3 offset;
    public float lerpRate;
    private bool gameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //offset is the distance between the camera and the ball
        offset = ball.transform.position - transform.position;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        //current position(from)
        Vector3 pos = transform.position;
        //target position(to)
        Vector3 targetPos = ball.transform.position - offset;
        //moves on from one value to another value with rate(lerpRate)
        //Time.deltatime - helps to run same on every computer
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }

    public void GameOver()
    {
        gameOver = true;
    }
}