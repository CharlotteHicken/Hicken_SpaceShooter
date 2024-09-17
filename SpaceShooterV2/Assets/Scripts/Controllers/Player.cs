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
    public float speed;

    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontalInput * speed, verticalInput * speed, 0);
        transform.position = transform.position + velocity * Time.deltaTime;
    }

}
