using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public AudioSource thunderstrike;
    public void goToGame(){
        thunderstrike.Play();
        SceneManager.LoadScene("MainGame");
    }
    public void doExitGame()
    {
        Application.Quit();
    }

    public void reloadGame(){
        thunderstrike.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
