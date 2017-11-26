using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseFollower : MonoBehaviour
{

    public float dragSpeed = 0.5f;
    public float zoomSpeed = 10f;

    private Vector3 dragOrigin;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }


        Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;





        if (!Input.GetMouseButton(0))
            return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed * -1, pos.y * dragSpeed * -1, 0);

        transform.Translate(move);
    }
}
