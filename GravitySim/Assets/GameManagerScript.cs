using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    //arrowKeys to add force
    //thrust on your rocket?
    //online?
    //timescale?
    //rotate planets?
    //reset round
    //settings
    //outOfBounds
    //toggle button to lock camera on player
    //speedup or slowdown time
    //scale thrust exponentially to distance?

    public int phase = 1; //1=addForces, 2=actionAndControlCamera
    public GameObject playerObject;
    public float distanceToForceConversionScalar = 7;
    public GameObject whiteBar;

    private Rigidbody2D playerRB;
    private float delayTimeForNextDottedLine = 0.15f;    //seconds
    private float timeForNextDottedLine;

    void Start () {
        //find player????????????????

        Time.timeScale = 0;
        playerRB = playerObject.GetComponent<Rigidbody2D>();
    }

	void Update () {
        if (phase == 2)
        {

            LookAt2D(playerRB.gameObject, playerRB.velocity);

            if (Time.time >= timeForNextDottedLine)
            {
                Instantiate(whiteBar, playerObject.transform.position, playerObject.transform.rotation);
                print(Time.time);
                timeForNextDottedLine += delayTimeForNextDottedLine;
            }
            
        }
        else if (phase == 1)
        {
            MousePositionInGameCordsAndRotateToward();
            if (Input.GetMouseButtonDown(1))    //rightClick
            {
                var distance = DistanceToMouseFromObject(playerObject);
                var forceMagnitude = distance * distanceToForceConversionScalar;
                print("D: " + distance + ", F:" + forceMagnitude);
                playerRB.AddForce(forceMagnitude * playerObject.transform.up);
                ChangePhase();
            }
        }
    }


    float DistanceToMouseFromObject(GameObject someObject)
    {
        var mousePosition = MousePositionInGameCordsAndRotateToward();
        var objectPosition = someObject.transform.position;

        var distanceVector = mousePosition - objectPosition;
        return distanceVector.magnitude;
    }

    Vector3 MousePositionInGameCordsAndRotateToward()
    {
        var mousePos = Input.mousePosition;
        var mouseObjectPos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseObjectPos.z = 0;
        LookAt2D(playerObject, mouseObjectPos);
        return mouseObjectPos;
    }

    void LookAt2D(GameObject myObject, Vector3 target)
    {
        var lookingVector = target - myObject.transform.position;
        var angle = Mathf.Atan2(lookingVector.y, lookingVector.x) * Mathf.Rad2Deg;
        myObject.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    void ChangePhase()
    {
        if (phase == 1)
        {
            phase = 2;
            Time.timeScale = 1f;
            timeForNextDottedLine += delayTimeForNextDottedLine;
        }
    }
}
