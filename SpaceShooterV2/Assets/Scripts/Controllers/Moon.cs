using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitRadius;
    public float orbitSpeed;
    float currentAngle = 0;

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitRadius, orbitSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        currentAngle += speed * Time.deltaTime;
        Vector3 movePosition = new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle)) * radius;

        transform.position = movePosition + target.position;
    }
}
