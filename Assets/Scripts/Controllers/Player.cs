using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    public Transform bombsTransform;

    [Header("Motion Properties")]
    float speed;
    Vector3 velocity;
    float maxSpeed;
    float accelerationTime;

    [Header("Bomb Properties")]
    public float inBombSpacing;
    public int inNumberOfBombs;
    public float inDistance;

    [Header("Radar Properties")]
    public float greenCircleRadius = 1f;
    public int numberOfSides = 6;

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

        PlayerMovement();
        PlayerRadar(greenCircleRadius, numberOfSides);
    }

    void PlayerMovement()
    {
        
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
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

    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {

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