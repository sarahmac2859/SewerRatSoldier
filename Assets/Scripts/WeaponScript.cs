﻿using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    /// <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;
    public Rigidbody2D rb;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingRate = 0.25f;

    //--------------------------------
    // 2 - Cooldown
    //--------------------------------

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(shootingRate, rb.velocity.y);
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab, transform.position, Quaternion.identity);

            // Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it
            EnemyScript move = shotTransform.gameObject.GetComponent<EnemyScript>();
            if (move != null)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    move.direction = this.transform.right; // towards in 2D space is the right of the sprite
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    move.direction = this.transform.right*-1; // towards in 2D space is the right of the sprite
                }
            }
        }
    }

    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}