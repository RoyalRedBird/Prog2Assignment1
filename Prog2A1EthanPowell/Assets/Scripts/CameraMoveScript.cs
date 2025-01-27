using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{

    [SerializeField] Transform cameraTransform;
    [SerializeField] AnimationCurve camCurve;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;     

        Vector3 camPos = cameraTransform.position;

        float camDistanceFromCenter = Vector2.Distance(Vector2.zero, camPos);

        float camDistanceSmoothed = camCurve.Evaluate(camDistanceFromCenter);

        camPos = Vector3.Lerp(Vector3.zero, mousePos, (camDistanceSmoothed/15));

        camPos.z = -10;

        cameraTransform.position = camPos;      

    }

}
