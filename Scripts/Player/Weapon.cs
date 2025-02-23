using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public bool weaponIsCollect = false;
    public float bulletForce = 750f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int damage = 40;
    public GameObject impactEffect;
    float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public GameObject firebtn;
    public void ClickFire()
    {
        if (weaponIsCollect)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Shoot();
            }
        }
    }
    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * bulletForce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(collision.gameObject);
            weaponIsCollect = true;
            firebtn.SetActive(true);
        }
    }
}
