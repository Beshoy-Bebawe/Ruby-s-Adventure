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

    // Start is called before the first frame update
    void Start()// Ruby's Health Part 1
    {
        rigidbody2d = GetComponent<Rigidbody2D>();// HealthCollectibe Part 2

        currentHealth = maxHealth;
        
    }


    // Update is called once per frame
    void Update()// MOVEMENT FOR RUBY aka Fixed Update and Update
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
            if (isInvincible)
         {
            invincibleTimer -= Time.deltaTime;//Damage Zone 
            if (invincibleTimer < 0)
            isInvincible = false;

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
    }
}