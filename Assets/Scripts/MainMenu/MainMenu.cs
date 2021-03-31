using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource menuMusic;

    private void Start()
    {
        menuMusic = GetComponent<AudioSource>();
        menuMusic.Play();
    }
    public void playGame()
    {
        menuMusic.Stop();
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        menuMusic.Stop();
        Debug.Log("Quit");
        Application.Quit();
    }
}
