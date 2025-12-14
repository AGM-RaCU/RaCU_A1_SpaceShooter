using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    void Update()
    {
        for (int i = 0; i < starTransforms.Count; i++)
        {
        Vector3 starV = starTransforms[i].position;
        Vector3 nextV = Vector3.Lerp(starTransforms[i].position, starTransforms[i + 1].position, drawingTime / Time.deltaTime);
            Debug.DrawLine(starV, nextV, Color.green);
        } 
    }
}
