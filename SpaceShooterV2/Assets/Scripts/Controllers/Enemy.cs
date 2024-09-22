using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float maxSpeed;
    float acceleration;
    public float accelerationRate;
    public Transform player;

    private void Start()
    {
        acceleration = maxSpeed / accelerationRate;
    }
    private void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * acceleration * Time.deltaTime;
    }

}
