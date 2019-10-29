using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbodyPlayer;
    public Animator animator;
    public GameObject gameCamera;

    private float horizontalMovement;
    private float verticalMovement;
    public bool isMoving = false;
    public float playerSpeed;
    private static int defaultMoveSpeed = 5;
    public bool isRight = true;

    public Rigidbody2D projectile;

    public Transform firePoint;

    public float firePower;
    public bool hasFired;
    
    public GameObject projectileRight;
    public GameObject projectileLeft;
    private Vector2 bulletPos;
    public float fireRate = 0.5f;
    private float nextFire = 0;

    public int enemiesKilled;
    public int bossHits;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //animator.SetBool("Forward", true);
        enemiesKilled = 0;
        bossHits = 0;
    }

    // Update is called once per frames
    private void Update()
    {
        
        MoveShip();
        ResetAnimDirection();
        AnimateShip();
        //animator.SetBool("Forward", true);

        

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            //Debug.Log(this.transform.position);

             // This else is not working properly
            //  if (Input.GetKey(KeyCode.A) && animator.GetBool("Turning") == true)
            //  {
            //      Debug.Log("left");
            //      animator.SetBool("Turning", false);
            //      //ChangeDirection();
            //      //animator.SetBool("Backward", true);
            //      isRight = false;
            //  }

            //  if (Input.GetKey(KeyCode.A) && animator.GetBool("Forward") == true)
            //  {
            //      animator.SetBool("Turning", true);

            //      if (animator.GetBool("Turning") == true)
            //      {
            //         Debug.Log("left");
            //         //animator.SetBool("Turning", false);
            //         isRight = false;
            //         animator.SetBool("Backward", true);
            //         animator.SetBool("Forward", false);
            //      }
            //      else
            //      {
            //         Debug.Log("Else is working");
            //         animator.SetBool("Turning", false);
            //         isRight = false;
            //         animator.SetBool("Backward", true);
            //      }
            //  }
            //  else
            //  {

            //  }

            //  if (Input.GetKey(KeyCode.D) && animator.GetBool("Backward") == true)// && isRight)
            //  {
            //      //animator.SetBool("Forward", true);
            //      animator.SetBool("Turning", true);

            //      if (animator.GetBool("Turning") == true)
            //      {
            //         Debug.Log("Right");
            //         //animator.SetBool("Turning", false);
            //         isRight = true;
            //         animator.SetBool("Forward", true);
            //      }
            //      else
            //      {
            //         animator.SetBool("Turning", false);
            //         animator.SetBool("Forward", true);
            //         isRight = true;
            //      }
            //  }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                //animator.SetBool("Turning", false);

                if (verticalMovement < 0)
                {
                    animator.SetBool("Down", true);
                }
                else 
                {
                    animator.SetBool("Up", true);
                    //Debug.Log("Up");
                }
            }
    
        }
        else 
        {
            // When not pressing keys, do stuff
            isMoving = false;
            //ResetAnimDirection();
            //isRight = true;
        }

        if (isMoving)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerSpeed = defaultMoveSpeed * 3;
            }
            else 
            {
                playerSpeed = defaultMoveSpeed;
            }
        }

         if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    private void FixedUpdate() 
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        rigidbodyPlayer.velocity = new Vector2(horizontalMovement * playerSpeed, verticalMovement * playerSpeed);

    }

    private void ResetAnimDirection()
    {
        animator.SetBool("Forward", false);
        animator.SetBool("Backward", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Turning", false);
        //isRight = true;
    }

    //Garbage function
    public void ChangeDirection()
    {
        animator.SetBool("Turning", false);
    }

    // projectile movement first attempt (Failed?)
    public void FireProjectile()
    {
        //GameObject temp = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        //temp.GetComponent<Rigidbody2D>().AddForce(Vector3.right * firePower);
        Rigidbody2D temp;
        temp = (Rigidbody2D)Instantiate(projectile, firePoint.position, firePoint.rotation);
        temp.velocity = firePoint.TransformDirection(Vector2.right * firePower);
    }

    // projectile movement second attempt
    private void Fire()
    {
        //bulletPos = transform.position;
        if (isRight)
        {
            //bulletPos += new Vector2(+1, -0.43f);
            Instantiate(projectileRight, firePoint.position, firePoint.rotation);
        }
        else if (!isRight)
        {
            //bulletPos += new Vector2(-1, -0.43f);
            Instantiate(projectileLeft, firePoint.position, firePoint.rotation);
        } 
    }

    // Attempt at moving that works but with no turning animation
    private void AnimateShip()
    {
        // Turning Left
        if (Input.GetAxisRaw("Horizontal") < 0 && animator.GetBool("Backward") == false)
        {
            isRight = false;
            //animator.SetBool("Turning", true);
            animator.SetBool("Backward", true);
            //firePoint.position = new Vector3(firePoint.transform.position.x - 0.25f,firePoint.transform.position.y,firePoint.position.z);
            
        }
        // Turning right
        else if (Input.GetAxisRaw("Horizontal") > 0 && animator.GetBool("Forward") == false)
        {
            isRight = true;
            //animator.SetBool("Turning", true);
            animator.SetBool("Forward", true);
            //firePoint.position = new Vector3(firePoint.transform.position.x + 0.25f, firePoint.transform.position.y,firePoint.position.z);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("Turning", false);
            // animator.SetBool("Forward", false);
            // animator.SetBool("Backward", false);
        }
    }

    //Trying something else for movement, didn't work
    private void AnimateShip2()
    {
        // Turning Left
        if (Input.GetAxisRaw("Horizontal") < 0 && isRight)
        {
            FlipPlayer();
            //animator.SetBool("Turning", true);
            animator.SetBool("Backward", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetBool("Backward", true);
        }

        // Turning right
        if (Input.GetAxisRaw("Horizontal") > 0 && !isRight)
        {
            FlipPlayer();
            //animator.SetBool("Turning", true);
            animator.SetBool("Forward", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("Forward", true);
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("Turning", false);
            // animator.SetBool("Forward", false);
            // animator.SetBool("Backward", false);
        }
    }
    private void MoveShip()
    {
        Vector3 shipMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        rigidbodyPlayer.transform.position += shipMovement * playerSpeed * Time.deltaTime;
    }

    private void FlipPlayer()
    {
        isRight = !isRight;
        animator.SetBool("Turning", true);
    }

    public void CountEnemies()
    {
        enemiesKilled++;
        //Debug.Log(enemiesKilled);
    }

    public void BossHealth()
    {
        bossHits++;
        //Debug.Log(bossHits);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            gameCamera.transform.parent = null;
            //Destroy(this.gameObject);
        }
        
    }
}
