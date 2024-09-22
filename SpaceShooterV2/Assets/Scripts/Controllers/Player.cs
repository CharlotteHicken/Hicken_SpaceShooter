using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    Vector3 velocity;

    float acceleration;
    float deceleration;
    public float maxSpeed;
    public float accelerateTime;
    public float decelerateTime;

    private void Start()
    {
        acceleration = maxSpeed / accelerateTime;
        deceleration = maxSpeed / decelerateTime;
    }

    void Update()
    {
        PlayerMovement();
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

}
