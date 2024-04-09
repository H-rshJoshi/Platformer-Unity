using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartButton()
    {
        SceneManager.LoadScene(1);
        Scoresystem.score = 0;
    }

    public void Playbutton()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void Quitbutton()
    {
        //to exit agme
        Application.Quit();
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
