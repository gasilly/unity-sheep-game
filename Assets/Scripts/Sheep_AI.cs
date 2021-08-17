using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep_AI : MonoBehaviour
{
    //Declaration of global variables for sheep AI
    [SerializeField] private float speed;
    private float vec;
    private float runAwayTimer;
    private bool afraid;
    private bool facingRight;
    private bool facingLeft;
    [SerializeField] private Animator anim;
    private Rigidbody2D rb;
    private Rigidbody2D otherRb;
    private Vector3 localScale;

    void Start() {
        //Set the localScale vector to this objects 
        localScale = transform.localScale;
        //Pick a random starting scale  for this sheep
        GetRandomNumber();
        transform.localScale = localScale;
        //Set the run to its starting time and afraid to false
        runAwayTimer = 5;
        afraid = false;
        //Get this sheeps rigidbody component
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //Check if the sheep is still running 
        RunningAway();
        //Check the velocity and flip the sprite if the sheep is moving right or left
        SheepDirection();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        //if anything other than the mouse causes the trigger just return
        if (other.tag != "Mouse")
        {
            return;
        }
            afraid = true;
            //Get the Vector between the mouse and the sheep
            Vector2 moveDir = gameObject.transform.position - other.transform.position;
            // Run away at the same velocity and direction as the mouse
            rb.velocity = moveDir * speed * Time.deltaTime;
    }
    void GetRandomNumber()
    {
        //Valid X values for local scale are -1 or 1 pick one on starting
        int[] valid = { -1, 1 };
        localScale.x = valid[Random.Range(0, valid.Length)];
    }
    void SheepDirection()
    {
        //Get the rigibody objects current x velocity and check if its less than or greater to 0. Set the boolean to either true or false.
        vec = rb.velocity.x;
        if (vec > 0)
        {
            facingRight = true;
        }
        else if (vec < 0)
        {
            facingRight = false;
        }
        //Change the direction if the current localScale and direction do not match. The velocity of the x direction must be greater than 0 as well
        if (((facingRight) && (localScale.x < 0) && (vec != 0)) || ((!facingRight) && (localScale.x > 0) && (vec != 0)))
        {
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    void RunningAway()
    {
        //if still running and afraid subtract time from the timer and play the running animation
        if (runAwayTimer >= 0 && afraid == true)
        {
            runAwayTimer = runAwayTimer - Time.deltaTime;
            anim.SetBool("Running", true);
        }
        //if afraid is true and the timer has hit 0 reset the velocity, fear and running velocity/animation
        else if (afraid == true && runAwayTimer < 0)
        {
            rb.velocity = new Vector2(0, 0);
            runAwayTimer = 5;
            anim.SetBool("Running", false);
            afraid = false;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Barn")
        {
            Destroy(this.gameObject);
        }
    }
}
