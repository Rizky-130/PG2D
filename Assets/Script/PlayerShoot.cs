using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireInterval = 0.5f;
    public float bulletSpeed = 8f;
    public float bulletLifetime = 3f;

    void Start()
    {
        InvokeRepeating(nameof(Shoot), 0f, Mathf.Max(0.01f, fireInterval));
    }

    void Shoot()
    {
        if (bulletPrefab == null)
        {
            return;
        }

        Transform spawnPoint = bulletSpawnPoint != null ? bulletSpawnPoint : transform;
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();

        if (bulletBody != null)
        {
            bulletBody.velocity = Vector2.up * bulletSpeed;
        }

        Destroy(bullet, bulletLifetime);
    }
}
