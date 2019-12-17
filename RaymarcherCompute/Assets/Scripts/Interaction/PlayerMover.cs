using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float constraintX;
    public float constraintY;

    public float moveSpeed;

    public KeyCode forward, back, left, right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(right))
        {
            Vector3 currentTransform = transform.position;
            float currentX = transform.position.x;
            currentX += moveSpeed;
            currentX = Mathf.Clamp(currentX, -constraintX, constraintX);
            transform.position = new Vector3(currentX, currentTransform.y, currentTransform.z);


        }
        else if (Input.GetKey(left))
        {
            Vector3 currentTransform = transform.position;
            float currentX = transform.position.x;
            currentX -= moveSpeed;
            currentX = Mathf.Clamp(currentX, -constraintX, constraintX);
            transform.position = new Vector3(currentX, currentTransform.y, currentTransform.z);
        }
    }
}
