using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWeapon : MonoBehaviour
{
    public float bulletForce = 750f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int damage = 40;
    float fireRate = 5f;
    private float nextFire = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * bulletForce);
    }
}
