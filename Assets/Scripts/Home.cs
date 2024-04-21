using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public AudioSource click;
    void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void PlayerScene()
    {
        click.Play();
        SceneManager.LoadScene("bau-cua-co-cop");
    }
    public void Exit()
    {
        click.Play();
        Application.Quit();
    }
}
