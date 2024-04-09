using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class girlRestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart_button()
    {
        SceneManager.LoadScene(2);
        Scoresystem.score = 0;
    }
    public void Level1()
    {
        SceneManager.LoadScene(1);
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
