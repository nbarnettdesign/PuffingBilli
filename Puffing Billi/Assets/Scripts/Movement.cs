using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Vector3 targetPosition;
    Rigidbody rb;
    Vector3 newDir;
    [SerializeField] float speed;
    [SerializeField] float minRotationSpeed;
    [SerializeField] float maxRotationSpeed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }

        if (targetPosition != Vector3.zero)
        {
            RotateToTarget();
        }

    }

    private void FixedUpdate()
    {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 targetPos = new Vector2(targetPosition.x, targetPosition.z);

        if (targetPosition != Vector3.zero && Vector2.Distance(playerPos, targetPos) >= 0.2f)
        {
            rb.MovePosition(transform.position + transform.forward * (speed * Time.deltaTime));
        }

    }
    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, 1 << LayerMask.NameToLayer("Raycast")))
        {
            targetPosition = hit.point;
        }
    }
    void RotateToTarget()
    {
        Vector3 dir = targetPosition - transform.position;
        float rotationSpeed = 0f;

        if (transform.forward.normalized == dir.normalized)
        {
            return;
        }

        if (Vector3.Distance(transform.position, targetPosition) <= 2.0f)
        {
            rotationSpeed = maxRotationSpeed;
        }
        if(Vector3.Distance(transform.position, targetPosition) >= 2.0f)
        {
            rotationSpeed = minRotationSpeed;
        }

         dir.y = 0; // keep the direction strictly horizontal
         Quaternion rot = Quaternion.LookRotation(dir);



         newDir = Vector3.RotateTowards(transform.forward, dir, rotationSpeed * Time.deltaTime, 0.0f);

         // Move our position a step closer to the target.
         transform.rotation = Quaternion.LookRotation(newDir);

         // slerp to the desired rotation over time
         // transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1.0f * Time.deltaTime);

         Debug.Log(rotationSpeed);
       
    }



}