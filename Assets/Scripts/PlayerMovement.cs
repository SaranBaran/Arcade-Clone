using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody rigidBody;
    private Vector3 moveDirection;

    void Update()
    {

        ProcessInput();

        //Player aim start
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.white);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);

            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
        }
        //finnish
    }
    void FixedUpdate()
    {

        Move();

    }
     void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 1 , moveZ).normalized;

    }
    void Move()
    {

        rigidBody.velocity = new Vector3(moveDirection.x * moveSpeed, 1 ,moveDirection.z * moveSpeed);
        
    }
}
