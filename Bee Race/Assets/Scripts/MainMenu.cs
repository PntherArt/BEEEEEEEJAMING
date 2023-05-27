using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string level;

    public GameObject[] canvas;

    public void Start()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(level);
    }

    public void InstrLoad()
    {
        canvas[0].SetActive(false);
        canvas[1].SetActive(true);
    }

    public void BackBtn()
    {
        canvas[1].SetActive(false);
        canvas[0].SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quit!");
    }
}
