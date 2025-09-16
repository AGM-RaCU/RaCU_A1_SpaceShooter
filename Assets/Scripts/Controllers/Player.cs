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
    public float velocity;

    void PlayerMovement()
    {
        Vector3 trans = transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = trans + Vector3.up * Time.deltaTime * velocity;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = trans + Vector3.down * Time.deltaTime * velocity;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = trans + Vector3.left * Time.deltaTime * velocity;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = trans + Vector3.right * Time.deltaTime * velocity;
        }

        if (trans.x = Screen.height)
        {

        }
    }

    void Update()
    {
        PlayerMovement();
    }

}