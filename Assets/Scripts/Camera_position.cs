using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_position : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        //rör kameran långasmt utåt för varje sekund som går
        transform.Translate(0f, 0f, -0.5f * Time.deltaTime);
    }
}
