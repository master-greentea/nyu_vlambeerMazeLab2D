using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Camera cam;
    // zooming stuff
    float xAxis, yAxis;
    public float zoomSpeed = .2f;

    // panning stuff
    public float panSpeed = 4.0f;
    private Vector3 mouseOrigin;
    private bool isPanning;

    public bool zoomed = false;
    public bool panned = false;

    void Update()
    {
        // check center
        if (FloorMaker.generatedTiles.Count > 0 && FloorMaker.generating) {
            xAxis = 0; yAxis = 0;
            for(int i = 0; i < FloorMaker.generatedTiles.Count; ++i) {
                xAxis += FloorMaker.generatedTiles[i].position.x;
                yAxis += FloorMaker.generatedTiles[i].position.y;
            }
            xAxis = xAxis/FloorMaker.generatedTiles.Count;
            yAxis = yAxis/FloorMaker.generatedTiles.Count;

            if (!panned) {
                cam.transform.position = new Vector3(xAxis, yAxis, -10);
            }

            // zoom
            if(cam.orthographicSize < 15 && !zoomed) {
                cam.orthographicSize += zoomSpeed;
            }
        }

        else if (!FloorMaker.generating) {
            // mouse zoom
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                cam.orthographicSize++;
                zoomed = true;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                cam.orthographicSize--;
                zoomed = true;
            }

            if (Input.GetMouseButtonDown(0)) 
            {
                mouseOrigin = Input.mousePosition;
                isPanning = true;
            }
    
    
            // cancel on button release
            if (!Input.GetMouseButton(0)) 
            {
                isPanning = false;
            }
    
            //move camera on X & Y
            if (isPanning) 
            {
                panned = true;
                Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
    
                Vector3 move = new Vector3(-pos.x * panSpeed, -pos.y * panSpeed, 0);
    
                transform.Translate(move, Space.World);
            }

            if (cam.orthographicSize < 1) {
                cam.orthographicSize = 1;
            }
        }
    }
}
