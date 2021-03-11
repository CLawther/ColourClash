
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //declaring variables to be used later to enable less jittery camera movemnts for a better overall gameplay experience
    public Transform goal;

    public Vector3 offset;

    [Range(0.01f, 1.0f)]
    public float Smooth = 0.6f;

    void Start()
    {
        offset = transform.position - goal.position;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = goal.position + offset;

        transform.position = Vector3.Slerp(transform.position, desiredPosition, Smooth);
    }
}
