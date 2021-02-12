// THIS IS A FUCKING MESS

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [HideInInspector] public static int delay;
    public GameObject controller;
    public Text HighScoreTXT;
    public Text SpeedPercentage;
    public Slider slider;

    private void Awake()
    {
        if (PlayerPrefs.GetFloat("delay") == 0)
        {
            SpeedTwo();
        }

        PlayerPrefs.SetFloat("easy_speed", 0.40f);
        PlayerPrefs.SetFloat("medium_speed", 0.30f);
        PlayerPrefs.SetFloat("hard_speed", 0.15f);
        
    }

    private void Start()
    {
        float perc = (100 - (PlayerPrefs.GetFloat("delay") * 100));
        SpeedPercentage.text = (Math.Round(perc).ToString() + "%");
        slider.GetComponent<Slider>().value = perc;
    }

    public float ReturnDelay()
    {
        return PlayerPrefs.GetFloat("delay");
    }

    public void SpeedOne() // easy
    {
        PlayerPrefs.SetFloat("delay", 0.40f);
        PlayerPrefs.SetString("mode", "easy");
        controller.GetComponent<ColorPicker>().restart();
    }

    public void SpeedTwo() // medium
    {
        PlayerPrefs.SetFloat("delay", 0.30f);
        PlayerPrefs.SetString("mode", "medium");

        controller.GetComponent<ColorPicker>().restart();

    }

    public void SpeedThree() // hard
    {
        PlayerPrefs.SetFloat("delay", 0.15f);
        PlayerPrefs.SetString("mode", "hard");

        controller.GetComponent<ColorPicker>().restart();
    }

    public void CustomSpeed()
    {
        // This code is messy AS FUCK, I feel bad for my future self trying to figure out wtf I was thinking when writing this.
        float speed = slider.value;  
        float absoluteSpeed = (100 - speed) / 100; // We do 100 - speed because the speed actually determins the delay. So if the slider is on 80
        // we need the 0.20 because how higher the slider, the higher our speed
        PlayerPrefs.SetFloat("delay", absoluteSpeed);
        
        if (absoluteSpeed >= PlayerPrefs.GetFloat("easy_speed") && absoluteSpeed > PlayerPrefs.GetFloat("medium_speed"))
        {
            PlayerPrefs.SetString("mode", "easy");
            PlayerPrefs.SetFloat("delay", absoluteSpeed);
            SpeedPercentage.text = (Mathf.Round(speed).ToString() + "% (easy)");

        }

        if (absoluteSpeed < PlayerPrefs.GetFloat("medium_speed") && absoluteSpeed > PlayerPrefs.GetFloat("hard_speed"))
        {
            PlayerPrefs.SetString("mode", "medium");
            PlayerPrefs.SetFloat("delay", absoluteSpeed);

            SpeedPercentage.text = (Mathf.Round(speed).ToString() + "% (medium)");

        }

        if (absoluteSpeed <  PlayerPrefs.GetFloat("hard_speed"))
        {
            PlayerPrefs.SetString("mode", "hard");
            PlayerPrefs.SetFloat("delay", absoluteSpeed);

            SpeedPercentage.text = (Mathf.Round(speed).ToString() + "% (hard)");

        }

    }

    // ============================================== END SPEED SETTINGS

    public void SetCheckHighScore(int score) 
    {
        // NOTE: It also gets edited in the color picker script.
       
        if (PlayerPrefs.GetString("mode") == "easy")
        {
            if (score > PlayerPrefs.GetInt("easy_points"))
            {
                PlayerPrefs.SetInt("easy_points", score);
                HighScoreTXT.text = "Easy high score: " + score.ToString();
            }
        }

        if (PlayerPrefs.GetString("mode") == "medium")
        {
            if (score > PlayerPrefs.GetInt("medium_points"))
            {
                PlayerPrefs.SetInt("medium_points", score);
                HighScoreTXT.text = "Medium score: " + score.ToString();
            }
        }

        if (PlayerPrefs.GetString("mode") == "hard")
        {
            if (score > PlayerPrefs.GetInt("hard_points"))
            {
                PlayerPrefs.SetInt("hard_points", score);
                HighScoreTXT.text = "Hard high score: " + score.ToString();

            }
        }
    }



    }
