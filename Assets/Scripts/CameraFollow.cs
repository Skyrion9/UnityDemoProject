using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public float height = 20;
    private float distCam = 0f;
    private float poscompensateCam = 0f;
    private float angle = 45;
    private float anglerad = 0f;

    Vector3 cameraAngleVector = Vector3.zero;  

    // Start is called before the first frame update
    void Start()
    {
        anglerad = angle * Mathf.Deg2Rad;
        distCam = height * Mathf.Abs(Mathf.Tan(anglerad));
        Debug.Log("DISTANCE VALUE : " + distCam + "TAN : " + Mathf.Abs(anglerad) + "posz" + player.position.z);
        poscompensateCam = distCam;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 target = player.position;
        target += Vector3.up * height;
        Vector3 lookahead = new(10f, 15f, 20f);
        cameraAngleVector = Vector3.right * angle;
        transform.eulerAngles = cameraAngleVector;
        target += Vector3.back * poscompensateCam;
        transform.position = target;

    }
}
