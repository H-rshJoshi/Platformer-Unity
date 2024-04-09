using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlGroundChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            Girl_movement.isJumping = true;
        }
    }

    //when player is in air
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            Girl_movement.isJumping = false;
        }
    }
}
