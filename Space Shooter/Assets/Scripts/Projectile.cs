using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float fireLimit;
    public GameObject projectile;
    public Transform player;
    public float velocityX = 5;
    private float velocityY = 0;
    private Rigidbody2D rigidbodyProjectile;
    public PlayerController playerReference;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyProjectile = GetComponent<Rigidbody2D>();
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerReference = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbodyProjectile.velocity = new Vector2(velocityX, velocityY);

        if (projectile.transform.position.x >= player.transform.position.x + fireLimit)
        {
            DestroyProjectile();
        }
        else if (projectile.transform.position.x <= player.transform.position.x - fireLimit)
        {
            DestroyProjectile();
        }           
       
    }

    public void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

    //This should be on triggerenter
    // private void OnCollisionEnter2D(Collision2D other) 
    // {
    //     if (other.gameObject.tag == "Enemy")
    //     {
    //         Destroy(this.gameObject);
    //         Destroy(other.gameObject);
    //         enemiesKilled += 1;
    //         //Debug.Log(enemiesKilled);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            playerReference.CountEnemies();
        }
        else if (other.gameObject.tag == "Boss")
        {
            Destroy(this.gameObject);
            playerReference.BossHealth();

            if (playerReference.bossHits >= 10)
            {
                Destroy(other.gameObject);
            }
        }
    }

}
