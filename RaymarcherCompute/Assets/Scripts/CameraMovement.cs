using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float distance = 5.0f; // we could make this a "zoom" - would not adjust fov
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float minDistance = 2f; // any closer and we will receive unpredicatable behavior - needs to be evaluated
    public float maxDistance = 15f;

    private float padScroll;

    private Rigidbody rigidbody;

    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(0))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y, yMinLimit, yMaxLimit);
            }
            

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            //scrolling
            
            distance = Mathf.Clamp(distance - GetScrollValue() * 5, minDistance, maxDistance);

            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
                distance -= hit.distance;
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    // get trackpad scroll
     void OnGUI()
    {
        if (Event.current.type == EventType.ScrollWheel)
        {
            padScroll = Event.current.delta.y / 100;
        } else
        {
            padScroll = 0;
        }
    }

    public float GetScrollValue()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (System.Math.Abs(scroll) < 0.001) // compare for floating point
        {
            scroll = padScroll;
        }
        return scroll;
    }
}