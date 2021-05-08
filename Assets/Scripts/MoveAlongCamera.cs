using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Location;

public class MoveAlongCamera : MonoBehaviour
{
    private Camera cam;
    public int schermX = Screen.width;
    public int schermY = Screen.height;
    float posX;
    float posZ;
    Vector3 pos;

    void Start()
    {
        cam = Camera.main;
        cam.rect = new Rect(schermX - 0.5f * schermX, schermY - 0.5f * schermY, schermX, schermY);
    }

    
    void Update()
    {
        posX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        posZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        pos = new Vector3(posX, 100, posZ);
        cam.transform.position = pos;
    }
}
