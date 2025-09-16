using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float maxSpeed = 1.0f;
    public float accelerationTime = 1.0f;

    private Vector3 velocity = Vector3.zero;

    void PlayerMovement()
    {
        float acceleration = maxSpeed / accelerationTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.down;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.right;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime;
    }

    void Update()
    {
        PlayerMovement();
    }

}