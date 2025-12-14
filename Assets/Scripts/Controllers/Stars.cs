using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    {
        //foreach (Transform star in starTransforms)
        //{
        for (int i = 0; i < starTransforms.Count; i++)
        {
        Vector3 starV = starTransforms[i].position;
        Vector3 nextV = Vector3.Lerp(starTransforms[i].position, starTransforms[i + 1].position, drawingTime / Time.deltaTime);
            //Vector
            //Debug.DrawLine(starV, transform.position, Color.red);
            //Debug.DrawLine(starV, starV[i], Color.green);
            //Debug.Log(starTransforms[i].position);
            //Debug.DrawLine(starTransforms[i].position, starTransforms[i+1].position, Color.green);
            Debug.DrawLine(starV, nextV, Color.green);

        }
        
    }
}
