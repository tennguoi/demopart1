using UnityEngine;

public class PlayerShooting1 : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float shootingInterval;
    private float lastBulletTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastBulletTime >
            shootingInterval)
            {
                ShootBullet();
                lastBulletTime = Time.time;
            }
        }

    }
    private void ShootBullet()
    {
        Instantiate(bulletPrefabs, transform.position, transform.rotation);
    }
}
