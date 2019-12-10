using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    //ini adalah variable referensi ke semua gameobject yang diperlukan dalam game
    public GameObject game;
    public GameObject gameUI;
    public GameObject mainMenuUI;
    public GameObject gameOverUI;
    public AudioSource bgm;

    private void Start()
    {
        //Di sini app kita akan mulai
        OnMainMenu();

    }

    //method ini akan dipanggil saat kita akan mulai permainan
    public void OnPlay()
    {
        //nonaktifkan semua dan aktifkan game dan gameUI
        TurnOffAllUI();
        gameUI.SetActive(true);
        game.SetActive(true);
        bgm.Play();
    }

    //method ini akan dipanggil saat kita akan masuk ke main menu
    public void OnMainMenu()
    {
        //nonaktifkan semua an aktifkan mainmenu UI
        TurnOffAllUI();
        mainMenuUI.SetActive(true);
        game.SetActive(false);
    }

    //method ini akan dipanggil saat gameover
    public void OnGameover()
    {
        //Matikan semua dan aktifkan game over UI
        TurnOffAllUI();
        game.SetActive(false);
        gameOverUI.SetActive(true);
        bgm.Pause();
    }

    //method ini me-nonaktifkan semua gameobject permainan
    public void TurnOffAllUI()
    {
        game.SetActive(false);
        gameUI.SetActive(false);
        mainMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
    }
}
