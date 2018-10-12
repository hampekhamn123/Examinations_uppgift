using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class asteroid_movement : MonoBehaviour
{

    private float positionX;
    private float positionY;
    public Transform other;
    private float asteroidSpeedX;
    private float asteroidSpeedY;
    private float rightSide = 9.8f;
    private float leftSide = -9.8f;
    private float upSide = 5.5f;
    private float downSide = -5.5f;

    void Start()
    {
        //Randomiserar startpositionen i x Axeln
        positionX = Random.Range(leftSide, rightSide);

        //Randomiserar startpositionen i y axeln
        positionY = Random.Range(downSide, upSide);

        //om asteroiderna har samma startposition som skeppet får asteroiden en ny position
        if (positionX == other.position.x && positionY == other.position.y)
        {
            //Randomiserar startpositionen i x Axeln
            positionX = Random.Range(leftSide, rightSide);

            //Randomiserar startpositionen i y axeln
            positionY = Random.Range(downSide, upSide);
        }
        
        //sätter ut den efter de randomiserade värdena
        transform.Translate(positionX, positionY, 0);

        asteroidSpeedX = Random.Range(1f, 10f);
        asteroidSpeedY = Random.Range(1f, 10f);

    }

    void Update()
    {
        //gör att asteroiderna åker ått ett specielt håll
        transform.Translate(asteroidSpeedX * Time.deltaTime, asteroidSpeedY * Time.deltaTime, 0);

        //warpar asteroiden till andra sidan skärmen om den åker för långt åt vänster
        if (transform.position.x < leftSide)
        {
            transform.position = new Vector3(rightSide, transform.position.y, transform.position.z);
        }

        //warpar asteroiden till andra sidan av skärmen om den åker för långt åt höger
        if (transform.position.x > rightSide)
        {
            transform.position = new Vector3(leftSide, transform.position.y, transform.position.z);
        }

        //warpar asteroiden till nedre sidan av skärmen om den åker för långt uppåt
        if (transform.position.y > upSide)
        {
            transform.position = new Vector3(transform.position.x, downSide, transform.position.z);
        }

        //warpar asteroiden till nedre sidan av skärmen om den åker för långt nedåt
        if (transform.position.y < downSide)
        {
            transform.position = new Vector3(transform.position.x, upSide, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EditorApplication.isPlaying = false;
    }
}
