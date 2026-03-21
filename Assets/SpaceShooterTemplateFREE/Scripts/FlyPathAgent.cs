using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed;
    private int nextIndex = 1;

    void Start()
    {
        if (flyPath == null || flyPath.waypoints.Length == 0) return;
        transform.position = flyPath.waypoints[0].transform.position;
    }

    void Update()
    {
        if (flyPath == null || flyPath.waypoints.Length == 0) return;
        if (nextIndex >= flyPath.waypoints.Length) return;

        Vector3 target = flyPath.waypoints[nextIndex].transform.position;

        if (Vector3.Distance(transform.position, target) > 0.01f)
        {
            FlyToNextWaypoint(target);
            LookAt(target);
        }
        else
        {
            nextIndex++;
        }
    }

    private void FlyToNextWaypoint(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            flySpeed * Time.deltaTime
        );
    }

    private void LookAt(Vector3 destination)
    {
        Vector3 direction = destination - transform.position;

        if (direction.magnitude < 0.01f) return;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // tuỳ sprite quay hướng nào:
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}