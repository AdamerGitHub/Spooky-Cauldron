using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public Vector3[] lookPositions;
    public int currentPosition = 0;
    public Transform lookAt;
    public float lookAtRotationXOffset = -15f;

    Quaternion camRotation;
    public Vector2 yawMinMax = new Vector2(-18, 18);

    public Vector2 pitchMinMax = new Vector2(-18, 18);

    float yaw;
    float pitch;

    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        if(currentPosition == 0){
            yaw += Input.GetAxisRaw("Horizontal") * rotateSpeed;
            pitch -= Input.GetAxisRaw("Vertical") * rotateSpeed;
            yaw = Mathf.Clamp(yaw, yawMinMax.x, yawMinMax.y);
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

            Vector3 targetRotation = new Vector3(pitch, yaw);
            transform.eulerAngles = targetRotation;
        }

        /*
        float dirY = Input.GetAxisRaw("Vertical") * -rotateSpeed;
        float dirX = Input.GetAxisRaw("Horizontal") * rotateSpeed;

        transform.Rotate(-rotateSpeed * dirY * Time.deltaTime, rotateSpeed * dirX * Time.deltaTime, 0);
        Vector3 currentEuler = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(currentEuler.x, currentEuler.y, 0); // drop z rotation value
        */




        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentPosition++;
            if (currentPosition >= lookPositions.Length)
            {
                currentPosition = 0;
            }
            if (currentPosition != 0)
            {
                transform.position = lookPositions[currentPosition];
                transform.LookAt(lookAt);
                transform.Rotate(lookAtRotationXOffset, 0, 0);
                print("YES");
            }
            else
            {
                transform.position = lookPositions[currentPosition];
                yaw = 0f;
                pitch = 0f;
                Vector3 targetRotation = new Vector3(pitch, yaw);
                transform.eulerAngles = targetRotation;
            }
        }
    }
}
