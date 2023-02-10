using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }
    

    void Update()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");

        yInput = yInput * speed * Time.deltaTime;
        xInput = xInput * speed * Time.deltaTime;

        transform.Translate(xInput, yInput, transform.position.z);

        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);

    }
}
