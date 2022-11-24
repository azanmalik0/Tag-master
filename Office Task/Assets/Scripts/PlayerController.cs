using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    private Rigidbody RB;
    public float targetSpeed;
    public Material playerMaterial;
    private int colorValue;
    public Color[] Colors;
    Vector3 startPos;

    private void Start()
    {
         RB = GetComponent<Rigidbody>();
        InvokeRepeating("ChangeColor", 0f,5f);
         startPos = transform.position;
        
    
    }

    void Update()
    {
        

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX,transform.position.y,moveZ);
        moveDirection*=speed*Time.deltaTime;
        RB.velocity = moveDirection;

       
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (playerMaterial.color == other.GetComponent<MeshRenderer>().material.color)
        {
            Destroy(other.gameObject);
        }
        else if (playerMaterial.color !=other.GetComponent<MeshRenderer>().material.color&& other.CompareTag("Target"))
        {
            transform.position = startPos;
        }




    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            //Destroy(gameObject);
            transform.position = startPos;
        }
        
        
    }
    void ChangeColor()
    {
        colorValue++;
        if (colorValue > 3)
        {
            colorValue = 0;
        }
        playerMaterial.color = Colors[colorValue];
    }


}


    