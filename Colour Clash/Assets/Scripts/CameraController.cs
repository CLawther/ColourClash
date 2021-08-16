using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform goal;

    public float smoothVelocity = 0.150f;

    public Vector3 offset;

    //To run after evrything else in order to make camera follow the player as it will be following behind
    private void LateUpdate()
    {
        //This position is where the camera snaps to
        Vector3 preferredPosition = goal.position + offset;
        //Gets preferred position even close depending on the smooth velocity
        Vector3 endPosition = Vector3.Lerp(transform.position, goal.position, smoothVelocity);
        //Cameras position equal to the goal position which will be the player
        transform.position = goal.position + offset;

        //Making sure the camera is always pointed at the player
        transform.LookAt(goal);
    }

}
