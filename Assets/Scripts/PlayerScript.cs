using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    public float xSpeed = 5f;
    public float ySpeed = 5f;
    void Update()
    {

        // Move the Character:
        animator.SetFloat("Running", Input.GetAxis("Horizontal"));

        transform.Translate(Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime, 0f, 0f);
        transform.Translate( 0f, Input.GetAxis("Vertical") * ySpeed * Time.deltaTime, 0f);
        // Flip 
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -2;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 2;
        }

        transform.localScale = characterScale;
        
        //Shoot rats 
        bool shoot = Input.GetKeyDown(KeyCode.Space);
        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }
        
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
        );
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rats"){
            Destroy(gameObject);
        }
    }
}


// ...
    

