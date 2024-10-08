using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameObject enemy;
    GameObject player;
    Vector3 playerPos;
    Transform enemyTransform;
    public float orbitRadius;
    public float orbitSpeed;
    float currentAngle = 0;
    public float closeness;

    void Start()
    {
        enemy = GameObject.Find("Enemy");
        enemyTransform = enemy.transform;
    }

    void Update()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
        OrbitalMotion(orbitRadius, orbitSpeed, enemyTransform);

        if ((transform.position - playerPos).magnitude <= closeness)
        {
            Destroy(gameObject);
        }
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        currentAngle += speed * Time.deltaTime;
        Vector3 movePosition = new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle)) * radius;

        transform.position = movePosition + target.position;
    }
}
