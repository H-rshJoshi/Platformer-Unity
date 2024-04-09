using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundChecker : MonoBehaviour
{

    //when player is on ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            Player_movement.isJumping = true;
        }
    }

    //when player is in air
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            Player_movement.isJumping = false;
        }
    }
    
}
