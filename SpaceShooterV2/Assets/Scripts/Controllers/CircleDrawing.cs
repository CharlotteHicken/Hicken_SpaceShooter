using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrawing : MonoBehaviour
{
    public List<float> angles;
    int currentAngleIndex;
    public float radius;
    Vector3 pointOnCircle;
    float degrees;
    float radians;
    int frameCount;
    public int timePass;
    // Start is called before the first frame update
    void Start()
    {
        currentAngleIndex = 0;
        frameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (frameCount == timePass)
        {
            if (currentAngleIndex >= angles.Count - 1)
            {
                currentAngleIndex = 0;
            }
            else
            {
                currentAngleIndex++;
            }
            frameCount = 0;
        }

        degrees = angles[currentAngleIndex];
        radians = degrees * Mathf.Deg2Rad;


        pointOnCircle = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;

        Debug.DrawLine(transform.position, transform.position + pointOnCircle, Color.green);
        frameCount++;
    }
}
