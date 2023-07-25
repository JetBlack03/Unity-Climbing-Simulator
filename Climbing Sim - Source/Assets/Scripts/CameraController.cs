using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public Transform target;
    public float rotateSpeed;
    public float heading;
    public float pitch;
    public float playerDistance = 8;

    public float minViewAngle = 45;
    public float maxViewAngle = 315;

    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {

        Cursor.lockState = CursorLockMode.Locked;
        //Get the x position of the mouse at rotate the target. 
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed; // Mouse X is horizontal.

        //Get Y position of the mouse and rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        //inputs
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        pitch -= Input.GetAxis("Mouse Y") * Time.deltaTime * 180;

        if (pitch < -20) pitch = -20;
        else if (pitch > 70) pitch = 70;

        Vector3 parentRot = Vector3.zero;
        Vector3 cameraRot = Vector3.zero;

        parentRot.y = heading - (float)System.Math.PI;
        cameraRot.x = pitch;

        transform.rotation = Quaternion.Euler(parentRot);
        transform.GetChild(0).localRotation = Quaternion.Euler(cameraRot);

        Vector3 newPos = target.position + new Vector3(0, 1, 0);

        float headingRadians = heading * ((float)System.Math.PI / 180) - (float)System.Math.PI;
        float pitchRadians = pitch * ((float)System.Math.PI / 180) /*- (float)System.Math.PI*/;

        float newPosX = 0;
        float newPosZ = 0;
        newPosX = (float)System.Math.Sin(headingRadians) * playerDistance;
        newPosZ = (float)System.Math.Cos(headingRadians) * playerDistance;

        newPosX *= (float)System.Math.Cos(pitchRadians);
        newPosZ *= (float)System.Math.Cos(pitchRadians);
        newPos.y += (float)System.Math.Sin(pitchRadians) * playerDistance + 0;
        newPos.x += newPosX;
        newPos.z += newPosZ;
        gameObject.transform.position = newPos;

    }
}
