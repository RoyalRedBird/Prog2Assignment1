using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{

    [SerializeField] Transform cameraTransform; //The transform of the camera.
    [SerializeField] AnimationCurve camCurve; //The animation curve to smooth out the camera movement.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Grabs the location of the mouse in the world fro  the camera.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;     

        //Grabs the transform of the camera.
        Vector3 camPos = cameraTransform.position;

        //Calculates the distance from the center of the screen to the mouse.
        float mouseDistanceFromCenter = Vector2.Distance(Vector2.zero, mousePos);

        //Evaluates the mouse distance from the center against the animation curve that I spent 20 minutes getting right.
        float mouseDistanceSmoothed = camCurve.Evaluate(mouseDistanceFromCenter);

        //Debug code.
        Debug.Log(mouseDistanceSmoothed);

        //Lerps the position of the camera between the middle of the game area and the position of the mouse using the smoothed mouse distance, divided by (whatever makes sense, it's 2 right now.)
        camPos = Vector3.Lerp(Vector3.zero, mousePos, (mouseDistanceSmoothed/2));

        //Sets the z position of the camera back to -10 so I can actually see the game.
        camPos.z = -10;

        //Applies the new camera position to the camera.
        cameraTransform.position = camPos;      

    }

}
