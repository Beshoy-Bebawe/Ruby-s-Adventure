using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;// Ruby's Movement
    public int maxHealth = 5;//Health Part 3

    public float  timeInvincible = 2.0f;

 public int health { get{ return currentHealth; }} // HealthCollectible.cs
    int currentHealth;

    bool isInvincible;//isInvincible states the damage zone 
    float invincibleTimer;
    
    Rigidbody2D rigidbody2d; // Movement And Colluison
    float horizontal;
    float vertical;
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    public GameObject projectilePrefab;




    // Start is called before the first frame update
    void Start()// Ruby's Health Part 1
    {
        animator =  GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();// HealthCollectibe Part 2

        currentHealth = maxHealth;
        
    }


    // Update is called once per frame
    void Update()// MOVEMENT FOR RUBY aka Fixed Update and Update
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);
        if (isInvincible)
         {
            invincibleTimer -= Time.deltaTime;//Damage Zone 
            if (invincibleTimer < 0)
            isInvincible = false;

         } 

        if(Input.GetKeyDown(KeyCode.E))
        {
            Launch();
        }     
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
        
    }

    public void ChangeHealth (int amount)  // Ruby's Health Part 2  and DamageZone Delay
    {
        if (amount < 0)
        {   
        if (isInvincible)    
           return;    
    
        isInvincible =true;
        invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    Debug.Log(currentHealth + "/" + maxHealth);
    UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);



    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f , Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");




    }


}