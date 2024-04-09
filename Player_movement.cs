using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public GameObject character;
    public Rigidbody2D RB;
    public float jumpforce;
    public static bool isJumping;
    public GameObject gameoverUI;
    public GameObject LevelcompleteUI;
    int lives = 3; //declaration of variable to make the lives icon disappear and end game if player touches the base
    public GameObject[] livesicon;
    public GameObject checkmark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        RB.velocity = new Vector2(RB.velocity.x + xInput * speed, RB.velocity.y);

        if(lives == 0)
        {
            anim.SetBool("isDead", true);
        }

        if(Input.GetKey(KeyCode.Space) && isJumping)
        {
            RB.AddForce(Vector2.up * jumpforce); 
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isWalkingRight", true);
        }
        else
        {
            anim.SetBool("isWalkingRight", false);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isWalkingLeft", true);
        }
        else
        {
            anim.SetBool("isWalkingLeft", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isJumpingRight", true);
        }
        else
        {
            anim.SetBool("isJumpingRight", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isJumpingLeft", true);
        }
        else
        {
            anim.SetBool("isJumpingLeft", false);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            Scoresystem.score++;
        }
        if(collision.gameObject.tag == "door")
        {
            LevelcompleteUI.SetActive(true);
            StartCoroutine(deadtimer());
            Player_movement player_Movement = GetComponent<Player_movement>();//variable initialization
            player_Movement.enabled = false;

        }
    }
    //coroutine
    IEnumerator deadtimer() {
        yield return new WaitForSeconds(2f);//code written after this will execute 4sec later
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "base")
        {
            //to make enemy 
            anim.SetBool("isDead", true);
            gameoverUI.SetActive(true);
            StartCoroutine(deadtimer());
            Player_movement player_Movement = GetComponent<Player_movement>();
            player_Movement.enabled = false;

        }
        if(collision.gameObject.tag == "enemy")
        {
            lives--; //makes the lives value as 2 so now in the next step the object at index value 2 of the livesicon array will be deleted. 
            livesicon[lives].SetActive(false);
        }
        if (lives <= 0)
        {
            anim.SetBool("isDead", true);
            gameoverUI.SetActive(true);
            StartCoroutine(deadtimer());
            Player_movement player_Movement = GetComponent<Player_movement>();
            player_Movement.enabled = false;
        }
    }

    public void MuteHandler(bool mute)
    {
        if (mute)
        {
            AudioListener.volume = 0;
            checkmark.SetActive(true);
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

}
