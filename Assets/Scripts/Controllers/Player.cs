using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    public Transform bombsTransform;

    //[Header("Motion Properties")]

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

        //PlayerMovement();
        PlayerRadar(greenCircleRadius, numberOfSides);
    }

    void PlayerMovement()
    {
        
    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawnPosition = transform.position + inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }

    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {

    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {

    }

    public void WarpPlayer(Transform target, float ratio)
    {

    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {

    }

    public void PlayerRadar(float greenCircleRadius, int numberOfSides)
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