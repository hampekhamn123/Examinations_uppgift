using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ship_movement : MonoBehaviour
{
    #region Ship
    public SpriteRenderer rend;
    private float boatSpeed;
    private int rotationSpeed = 5;
    private int boatMinSpeed = 3;
    private int boatMaxSpeed = 11;
    #endregion

    #region timer 
    public float timerSeconds = 0;
    private int timerMinutes = 0;
    private int timerHours = 0;
    private float currentTime = 1;
    #endregion
    
    #region Colour
    private float newColor1;
    private float newColor2;
    private float newColor3;
    public Color boatColor;
    #endregion

    #region positions

    private float startPositionX;
    private float startPositionY;
    private float startPositionZ = 0;
    #endregion

    #region warps
    private float rightSide = 9.8f;
    private float leftSide = -9.8f;
    private float upSide = 5.5f ;
    private float downSide = -5.5f;
    #endregion

    void Start()
    {
        //Randomiserar startpositionen i x axeln
        startPositionX = Random.Range(leftSide, rightSide);

        //Randomiserar startpositionen i y axeln
        startPositionY = Random.Range(downSide, upSide);
        
        //Ändrar startpositionen
        transform.Translate(startPositionY, startPositionX, startPositionZ);

        //Randomiserar båtens hastiget
        boatSpeed = Random.Range(boatMinSpeed, boatMaxSpeed);
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

        //när A trycks ner svänger båter åt vänster och blir grön
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, rotationSpeed / 2);
            rend.color = Color.green;
        }

        //när D trycks new svänger båten åt höger och blir blå
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -rotationSpeed);
            rend.color = Color.blue;
        }

        //gör att timern går upp i realtid istället för efter frames
        timerSeconds += Time.deltaTime;
        
        //gör att den bara skriver ut koden en gång varje sekund
        if (timerSeconds > currentTime && timerSeconds < currentTime + 0.2)
        {
            print(string.Format(
                "timer: {0}H:{1}M:{2}S", timerHours, timerMinutes, (int)timerSeconds));
            currentTime = (currentTime + 1);
        }

        //gör att minuterna går upp
        if (timerSeconds >= 60)
        {
            timerMinutes = (timerMinutes + 1);
            timerSeconds = 0;
            currentTime = 1;
        }

        //gör att sekunderna går upp
        if (timerMinutes == 60)
        {
            timerHours = (timerHours + 1);
            timerMinutes = 0;
        }

        newColor1 = Random.Range(0f, 1.1f);
        newColor2 = Random.Range(0f, 1.1f);
        newColor3 = Random.Range(0f, 1.1f);

        //ger båten en randomiserad färg om space trycks ner
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rend.color = new Color(newColor1, newColor2, newColor3);
        }

        //warpar båten till andra sidan skärmen om den åker för långt åt vänster
        if (transform.position.x < leftSide)
        {
            transform.position = new Vector3(rightSide, transform.position.y, transform.position.z);
        }

        //warpar båten till andra sidan av skärmen om den åker för långt åt höger
        if (transform.position.x > rightSide)
        {
            transform.position = new Vector3(leftSide, transform.position.y, transform.position.z);
        }

        //warpar båten till nedre sidan av skärmen om den åker för långt uppåt
        if (transform.position.y > upSide)
        {
            transform.position = new Vector3(transform.position.x, downSide, transform.position.z);
        }

        //warpar båten till nedre sidan av skärmen om den åker för långt nedåt
        if (transform.position.y < downSide)
        {
            transform.position = new Vector3(transform.position.x, upSide, transform.position.z);
        }
        //hastigheten ökar för varje sekund som spelet är igång
        boatSpeed = (boatSpeed + (Time.deltaTime / 3));

    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            EditorApplication.isPlaying = false;
        }
}
