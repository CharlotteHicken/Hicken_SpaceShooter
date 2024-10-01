using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject player;
    public float maxSpeed;
    float acceleration;
    public float accelerationRate;
    Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
        float angle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        acceleration = maxSpeed / accelerationRate;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        Vector3 direction = (playerPos - transform.position).normalized;

        transform.position += direction * acceleration * Time.deltaTime;

        if ((playerPos - transform.position).magnitude <= 0.1)
        {
            Destroy(gameObject);
        }
    }
}
