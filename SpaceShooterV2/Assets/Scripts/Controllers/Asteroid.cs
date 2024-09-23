using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    Vector3 destinationGoal;

    // Start is called before the first frame update
    void Start()
    {
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {
        transform.position = Vector3.Lerp(transform.position, destinationGoal, moveSpeed * Time.deltaTime);

        float almostThere = (transform.position - destinationGoal).magnitude;

        if (almostThere < arrivalDistance)
        {
            SetDestination();
        }
    }

    public void SetDestination()
    {
        float xValue = Random.Range(-maxFloatDistance, maxFloatDistance);
        float yValue = Random.Range(-maxFloatDistance, maxFloatDistance);

        destinationGoal = new Vector3(transform.position.x + xValue, transform.position.y + yValue, 0);
    }
}
