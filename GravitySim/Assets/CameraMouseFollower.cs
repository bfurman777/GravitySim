using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseFollower : MonoBehaviour
{

    public float dragSpeed = 0.005f;
    public float zoomSpeed = 10f;
	public float maxZoom = 0.5f;

    private Vector3 dragOrigin;
    private SpriteRenderer nightSky;

    void Start()
    {
        nightSky = this.GetComponentInChildren<SpriteRenderer>();
        nightSky.enabled = true;
    }

    void Update()
    {
        DragScreen();
        ZoomScreen();
    }


    void DragScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0))
            return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3(pos.x * dragSpeed * -1, 
			pos.y * dragSpeed * -1, 0);

        transform.Translate(move);
    }

    void ZoomScreen()
    {
        Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		if (Camera.main.orthographicSize <= maxZoom) {
			Camera.main.orthographicSize = maxZoom;
		}
        ResizeSpriteToScreen();
    }

     void ResizeSpriteToScreen() {
        if (nightSky == null) return;
     
        nightSky.transform.localScale = new Vector3(1,1,1);
     
        float width = nightSky.sprite.bounds.size.x;
        float height = nightSky.sprite.bounds.size.y;
     
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        nightSky.transform.localScale = new Vector3(worldScreenWidth / width + 1, 
            worldScreenHeight / height + 1, 1);
    }
}
