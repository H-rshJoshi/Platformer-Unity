using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockspawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var clonerock = Instantiate(rock, transform.position, transform.rotation);
            Destroy(clonerock, 1.5f);
        }
    }
}
