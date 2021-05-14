using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Se encarga de pausar el juego y mostrar un popup de pausa cuando pulsamos la tecla escape
/// </summary>
public class MenuPause : MonoBehaviour
{
    public GameObject pauseMenu;	

    /// <summary>
    /// Unity Update
    /// </summary>
    void Update()
    {
        // Si pulsamos la tecla 'escape' pausamos o reanudamos el juego dependiendo del flag _isPaused
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }

            isPaused = !isPaused;
        }
    }

    /// <summary>
    /// Pausa el juego poniendo el Time.timeScale a 0. También muestra el menú de pausa
    /// </summary>
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Continúa el juego poniendo el Time.timeScale a 1. También oculta el menú de pausa
    /// </summary>
    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }


    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    private bool isPaused = false;
}
