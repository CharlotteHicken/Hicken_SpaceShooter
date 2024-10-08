using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float maxSpeed;
    float acceleration;
    public float accelerationRate;
    public Transform player;
    public int spawnTime;
    int currentFrame;
    public GameObject rocketPrefab;
    public GameObject bombPrefab;

    private void Start()
    {
        currentFrame = 0;
        acceleration = maxSpeed / accelerationRate;
    }
    private void Update()
    {
        if (currentFrame > spawnTime)
        {
            Instantiate(rocketPrefab, transform.position, Quaternion.identity);
            Instantiate(bombPrefab);
            currentFrame = 0;
        }
        MoveToPlayer();
        currentFrame++;
    }

    void MoveToPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * acceleration * Time.deltaTime;
    }

}
