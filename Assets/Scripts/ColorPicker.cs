using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public GameObject red;
    public GameObject blue;
    public GameObject yellow;
    public GameObject green;
    public GameObject gameOverUI;
    public GameObject menu;
    public GameObject controller;
    public GameObject DelayPanel;
    public Text HighScore;
    public GameObject CustomSpeedPanel;


    private int turn = 1;
    private int steps = 0;
    private bool iter = true;
    private int count;
    List<int> order = new List<int>();
    private bool game_over = false;
    private float delay;

    private void Start()
    {
        delay = controller.GetComponent<Settings>().ReturnDelay();

    }

    private void Update()
    {
        if (game_over == false || menu.activeSelf == false || DelayPanel.activeSelf == false || CustomSpeedPanel.activeSelf == false)
        {
            if (turn == 1)
            {
                if (iter)
                {
                    count = 0;
                    steps = 0;
                    iter = false;
                    order.Add(Random.Range(1, 5));
                    StartCoroutine(enable(order));
                }
            }

            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    green.SetActive(false);
                    yellow.SetActive(false);
                    red.SetActive(false);
                    blue.SetActive(false);
                }
            }
        }
        
    }

    IEnumerator enable(List<int> ordr)
    {
        controller.GetComponent<UiScript>().EditPoints();

        foreach (int i in order)
        {

            yield return new WaitForSeconds(delay); 

            green.SetActive(false);
            yellow.SetActive(false);
            red.SetActive(false);
            blue.SetActive(false);

            yield return new WaitForSeconds(delay); 


            if (i == 1)
            {
                yellow.SetActive(true);
            }

            if (i == 2)
            {
                blue.SetActive(true);
            }

            if (i == 3)
            {
                red.SetActive(true);
            }

            if (i == 4)
            {
                green.SetActive(true);
            }

            count++;
            if (count == order.Count)
            {
                yield return new WaitForSeconds(delay);

                green.SetActive(false);
                yellow.SetActive(false);
                blue.SetActive(false);
                red.SetActive(false);

                turn--;

            }

        }
    }

    

    public IEnumerator onclick(int pos)
    {
        if (turn == 0 && game_over == false && menu.activeSelf == false && steps < order.Count && DelayPanel.activeSelf == false && CustomSpeedPanel.activeSelf == false)
        {
            if (pos == order[steps])
            {
                steps++;

                if (steps == order.Count)
                {
                    yield return new WaitForSeconds(delay * 0.8f); 
                    turn++;
                    iter = true;
                }
            }
            else
            {
                // HERE THINGS AFTER THE GAMEOVER HAPPEN
                // Note to future self: Please optimise this code and move it to somewhere else in the future, it does not belong in this script.
                game_over = true;
                gameOverUI.SetActive(true);

                controller.GetComponent<Settings>().SetCheckHighScore(controller.GetComponent<UiScript>().ReturnScore());
                if (PlayerPrefs.GetString("mode") == "easy")
                {
                    string max_score = PlayerPrefs.GetInt("easy_points").ToString();
                    HighScore.text = "Easy high score: " + max_score;
                }

                if (PlayerPrefs.GetString("mode") == "medium")
                {
                    string max_score = PlayerPrefs.GetInt("medium_points").ToString();
                    HighScore.text = "Medium high score: " + max_score;
                }

                if (PlayerPrefs.GetString("mode") == "hard")
                {
                    string max_score = PlayerPrefs.GetInt("hard_points").ToString();
                    HighScore.text = "Hard high score: " + max_score;
                }

            }
        }    
    }


    public void glow(int position)
    {   
        // Should probably use a switch statement
        if (turn == 0 && game_over == false && menu.activeSelf == false && DelayPanel.activeSelf == false && CustomSpeedPanel.activeSelf == false)
        {
            if (position == 1)
            {
                yellow.SetActive(true);
            }

            if (position == 2)
            {
                blue.SetActive(true);
            }

            if (position == 3)
            {
                red.SetActive(true);
            }

            if (position == 4)
            {
                green.SetActive(true);
            }
        }
    }


    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
