﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_movement : MonoBehaviour
{
    public SpriteRenderer rend;
    private float boatSpeed = 5;
    public Color boatColor;
    private int rotationSpeed = 3;
    public float timer = 0;
    private float currentTime = 1;
    private float newColor1;
    private float newColor2;
    private float newColor3;

    void Start()
    {

    }

    void Update()
    {
        //skeppet åker uppåt i y axeln i hastigheten 5 oavset FPS
        transform.Translate(0, boatSpeed * Time.deltaTime, 0);

        //när S trycks ner vill den halva hastigheten åt andra hållet vilket reducerar hastigheten
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, (-boatSpeed / 2) * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, rotationSpeed / 2);
            rend.color = Color.green;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -rotationSpeed);
            rend.color = Color.blue;
        }

        timer += Time.deltaTime;

        if (timer > currentTime && timer < currentTime + 0.2)
        {
            print("timer:" + " " + (int)timer);
            currentTime = (currentTime + 1);
        }
        /*
        newColor1 = Random.Range(0f, 1.1f);
        newColor2 = Random.Range(0f, 1.1f);
        newColor3 = Random.Range(0f, 1.1f);

        if (Input.GetKey(KeyCode.Space))
        {
            rend.color = new Color(newColor1, newColor2, newColor3);
        }
        */
    }
}
