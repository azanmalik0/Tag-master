using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Vector3[] points;
    public float speed;
    private int nextPointIndex=0;
    public Material targetMaterial;


    void Start()
    {
        
    }

  
    void Update()
    {
        var reachedPointIndex = transform.position == points[nextPointIndex];
        if (reachedPointIndex)
        {
            nextPointIndex++;
            if(nextPointIndex>=points.Length)
            {
                nextPointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[nextPointIndex], speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Red"))
        {
            targetMaterial.color = Color.red;
            //other.gameObject.tag = "red";
            
        }
        if(other.CompareTag("Yellow"))
        {
            targetMaterial.color = Color.yellow;
            //other.gameObject.tag = "yellow";

        }
        if(other.CompareTag("Blue"))
        {
            targetMaterial.color = Color.blue;
            //other.gameObject.tag = "blue";

        }
        if(other.CompareTag("Green"))
        {
            targetMaterial.color = Color.green;
            //other.gameObject.tag = "green";

        }
    }
}
