using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private Transform targetToFollow;
    [SerializeField] private float maxLagOnXAxis;
    [SerializeField] private float maxLagOnYAxis;
    [SerializeField] private float speed;



    void Start()
    {
        
    }


    void Update()
    {
        float xDistanceToTarget = Mathf.Abs(targetToFollow.position.x - transform.position.x);
        float yDistanceToTarget = Mathf.Abs(targetToFollow.position.y - transform.position.y);

        if (xDistanceToTarget > maxLagOnXAxis || yDistanceToTarget > maxLagOnYAxis)
        {
            MoveCamera();
        }
    }


    void MoveCamera()
    {
        float step = speed * Time.deltaTime;
        Vector3 targetPosition = new Vector3(targetToFollow.position.x, targetToFollow.position.y, transform.position.z);
        // move sprite towards the target location
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
