using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] float zoomSpeed = 1;
    [SerializeField] float zoom = 5;
    [SerializeField] bool colorKiller;
    [SerializeField] float colorChangeSpeed;

    float initialSize;
    Camera camera;
    Color newColor;

    void Start()
    {
        camera = GetComponent<Camera>();
        newColor = camera.backgroundColor;
        initialSize = camera.orthographicSize;
        camera.orthographicSize = zoom + camera.orthographicSize;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        //if (camera.orthographicSize > initialSize)
        //{
        //    camera.orthographicSize -= ;
        //}
        if (colorKiller && camera.backgroundColor == newColor)
        {
            newColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        }

        else if (colorKiller)
        {
            camera.backgroundColor = Color.Lerp(camera.backgroundColor, newColor, Time.deltaTime * colorChangeSpeed);
        }


        if (camera.orthographicSize > initialSize)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, initialSize, Time.deltaTime * zoomSpeed);
        }
    }
}
