using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseFollower : MonoBehaviour
{

    public float dragSpeed = 0.1f;
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
		if (Camera.main.orthographicSize <= 0.00001f) {
			Camera.main.orthographicSize = 0.00001f;
		}




        if (!Input.GetMouseButton(0))
            return;

		var cameraScalar = Camera.main.orthographicSize/3;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3(pos.x * dragSpeed * -1 * cameraScalar, 
			pos.y * dragSpeed * -1 * cameraScalar, 0);

        transform.Translate(move);
    }
}
