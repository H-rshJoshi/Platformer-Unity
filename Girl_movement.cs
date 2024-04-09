using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject girlcharacter;
    public Rigidbody2D girlRB;
    public float jumpforce;
    public float speed;
    public static bool isJumping;
    public Animator anim;
    public GameObject gameoverUI;
    public GameObject levelcompleteUI;
    int lives = 3;
    //public GameObject heart;
    public GameObject checkmarkaudio;
    public GameObject[] livesicons;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xinput = Input.GetAxisRaw("Horizontal");
        girlRB.velocity = new Vector2(girlRB.velocity.x + xinput * speed, girlRB.velocity.y);
        if (lives == 0)
        {
            anim.SetBool("isDead", true);
        }
        
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            girlRB.AddForce(Vector2.up * jumpforce);
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
        if(collision.gameObject.tag == "apple")
        {
            Destroy(collision.gameObject);
            Girlscoresystem.Score++;
        }
        if(collision.gameObject.tag == "chest")
        {
            levelcompleteUI.SetActive(true);
            StartCoroutine(deadtimer());
            Girl_movement movement = GetComponent<Girl_movement>();
            movement.enabled = false;
        }
    }

    IEnumerator deadtimer()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "basegirl")
        {
            anim.SetBool("isDead", true);
            gameoverUI.SetActive(true);
            StartCoroutine(deadtimer());
            Girl_movement hello = GetComponent<Girl_movement>();
            hello.enabled = false;
        }
        if (collision.gameObject.tag == "kraken")
        {
            lives--;
            livesicons[lives].SetActive(false);
        }
        if(lives <= 0)
        {
            anim.SetBool("isDead", true);
            gameoverUI.SetActive(true);
            StartCoroutine(deadtimer());
            Girl_movement movement = GetComponent<Girl_movement>();
            movement.enabled = false;
        }
    }

    public void MuteHandler(bool mute)
    {
        if (mute)
        {
            AudioListener.volume = 0;
            checkmarkaudio.SetActive(true);
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

}
