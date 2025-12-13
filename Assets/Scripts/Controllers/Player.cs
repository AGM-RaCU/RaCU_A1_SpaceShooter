using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    public Transform bombsTransform;

    [Header("Motion Properties")]
    private Vector3 velocity;
    public float maxSpeed;
    public float accelerationTime, decelerationTime;
    private float acceleration, deceleration;

    [Header("Bomb Properties")]
    public float inBombSpacing;
    public int inNumberOfBombs;
    public float inDistance;

    [Header("Radar Properties")]
    public float greenCircleRadius = 1f;
    public int numberOfSides = 6;

    [Header("Warp Drive Properties")]
    public Transform target;
    public float ratio = 1f;

    [Header("Detector Properties")]
    public float inMaxRange = 2.5f;
    public List<Transform> inAsteroids;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(0, 1));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnBombTrail(inBombSpacing, inNumberOfBombs);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnBombOnRandomCorner(inDistance);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            WarpPlayer(target, ratio);
        }

        PlayerMovement();
        PlayerRadar(greenCircleRadius, numberOfSides);
        DetectAsteroids(inMaxRange, asteroidTransforms);
    }

    void PlayerMovement()
    {
        Vector2 playerInput = Vector2.zero;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            playerInput += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerInput += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerInput += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerInput += Vector2.right;
        }

        if(playerInput.magnitude > 0)
        {
            velocity += (Vector3)playerInput.normalized * acceleration * Time.deltaTime;
        
            if(velocity.magnitude > maxSpeed)
            {
                velocity = velocity.normalized * maxSpeed;
            }
        }
        else
        {
            Vector3 changeV = velocity.normalized * deceleration * Time.deltaTime;
            if(changeV.magnitude > velocity.magnitude)
            {
                velocity = Vector3.zero;
            }
            else
            {
                velocity -= changeV;
            }
 
        }

            transform.position += velocity * Time.deltaTime;
    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawnPosition = transform.position + inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }

    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        for (int i = 0; i < inNumberOfBombs; i++)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, i * inBombSpacing, 0);
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        Vector3 CornerPos = new Vector3(Random.Range(-1, 2)*inDistance, Random.Range(1, -2)*inDistance, 0);
        Vector3 spawnPos = new Vector3(transform.position.x + CornerPos.x, transform.position.y + CornerPos.y, 0);
        Instantiate(bombPrefab, spawnPos, Quaternion.identity);
    }

    public void WarpPlayer(Transform target, float ratio)
    {
        transform.position = Vector3.Lerp(transform.position, target.position, ratio);
    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform asteroid in inAsteroids)
        {
            float distance = Vector3.Distance(asteroid.position, transform.position);
            //Debug.Log(distance);

            Vector3 asteroidV = asteroid.position;
            Vector3 playerV = transform.position;

            //Vector3 directionV = playerV.normalized + asteroidV;
            //Debug.Log(directionV);

            if (inMaxRange >= distance)
                {
                //Debug.DrawLine(playerV, directionV, Color.red);
                Debug.DrawLine(playerV, asteroidV, Color.red);
            }
        }
        
        //Transform currentTransform = inAsteroids[0];

        //Debug.Log(currentTransform.position);
    }

    void PlayerRadar(float greenCircleRadius, int numberOfSides)
    {
        float angleStep = 360f / numberOfSides;
        float radians = angleStep * Mathf.Deg2Rad;

        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < numberOfSides; i++)
        {

            float adjustment = radians * i;
            Vector3 point = new Vector3(Mathf.Cos(radians + adjustment), Mathf.Sin(radians + adjustment)) * greenCircleRadius;
            points.Add(point);
        }

        Vector3 center = transform.position;

        for (int i = 0; i < points.Count - 1; i++)
        {
            Debug.DrawLine(center + points[i], center +  points[i + 1], Color.green);
        }
        Debug.DrawLine(center + points[points.Count - 1], center + points[0], Color.green);
    }

}    