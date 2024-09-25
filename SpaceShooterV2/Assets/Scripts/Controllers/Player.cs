using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public GameObject powerupPrefab;
    public Transform bombsTransform;
    Vector3 velocity;

    float acceleration;
    float deceleration;
    public float maxSpeed;
    public float accelerateTime;
    public float decelerateTime;
    public float detectRadius;
    public int radiusPointNumber;
    public float powerupRadius;
    public int powerupNumber;

    private void Start()
    {
        acceleration = maxSpeed / accelerateTime;
        deceleration = maxSpeed / decelerateTime;
    }

    void Update()
    {
        PlayerMovement();
        EnemyRadar(detectRadius, radiusPointNumber);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPowerups(powerupRadius, powerupNumber);
        }
    }

    public void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputValues = new Vector3(horizontalInput, verticalInput, 0);

        if (inputValues.magnitude != 0)
        {
            velocity += inputValues * acceleration * Time.deltaTime;
        }
        else
        {
            velocity -= velocity * deceleration * Time.deltaTime;
        }

        if (velocity.magnitude < 0.001f)
        {
            velocity = Vector3.zero;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime;
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        Color lineColor;
        if ((enemyTransform.position - transform.position).magnitude <= radius)
        {
            lineColor = Color.red;
        }
        else
        {
            lineColor = Color.green;
        }
        
        float degrees = 360 / circlePoints;
        float radians = degrees * Mathf.Deg2Rad;

        for (int i = 0; i <= circlePoints; i++)
        {
            Vector3 currentPoint = new Vector3(Mathf.Cos(radians + (radians * i)), Mathf.Sin(radians + (radians * i))) * radius;
            Vector3 nextPoint = new Vector3(Mathf.Cos(radians + (radians * (i+1))), Mathf.Sin(radians + (radians * (i+1)))) * radius;
            Debug.DrawLine(transform.position + currentPoint, transform.position + nextPoint, lineColor);
        }
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float degrees = 360 / numberOfPowerups;
        float radians = degrees * Mathf.Deg2Rad;

        for (int i = 0; i <= numberOfPowerups; i++)
        {
            Vector3 spawnPoint = new Vector3(Mathf.Cos(radians + (radians * i)), Mathf.Sin(radians + (radians * i))) * radius;
            Instantiate(powerupPrefab, transform.position + spawnPoint, Quaternion.identity);
        }
    }

}
