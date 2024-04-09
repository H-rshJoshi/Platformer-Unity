using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoresystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score;
    public TMP_Text Scoretext;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = score.ToString();
    }
}
