﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TakeItemManager : MonoBehaviour
{
    public Text _coinText;
    private int _coinCount;
    public GameObject _powerUpText;
    public static bool PowerF = false;
    public GameObject ballF;
    public Transform Spawn;
    public static int stars = 0;
    public GameObject final;
    private bool PauseGame;
    public Text finalCoinsText;
    public Text finalStarsText;
    public static bool activeAsteroid;
    public AudioSource finishSound;
    public AudioSource coinSound;
    public AudioSource powerUpSound;

    void Start()
    {
        _powerUpText.SetActive(false);
        PauseGame = false;
        final.SetActive(false);
        activeAsteroid = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PowerF == true)
        {
            powerUpSound.Play();
            Instantiate(ballF, Spawn);
        }

        if (PauseGame == true)
        {
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag.Equals("Coin") || collider2D.tag.Equals("CoinPuerta"))
        {
            _coinCount++;
            _coinText.text = _coinCount.ToString();
            coinSound.Play();

            Destroy(collider2D.gameObject);
        }

        if (collider2D.tag.Equals("PowerUPF"))
        {
            PowerF = true;
            _powerUpText.SetActive(true);
            Destroy(collider2D.gameObject);
        }

        if (collider2D.tag.Equals("Finish"))
        {
            stars++;
            PauseGame = true;
            final.SetActive(true);
            finalCoinsText.text = _coinCount.ToString();
            finalStarsText.text = stars.ToString();
            TotalItems.totalCoins = TotalItems.totalCoins + _coinCount;
            TotalItems.totalStars = TotalItems.totalStars + stars;
            finishSound.Play();
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene(0);
        PowerF = false;
    }
}