using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiScript : MonoBehaviour
{
    // NOTE: The ui for the game over part is not in this script, but in the ColorPicker script. 
    public GameObject pnl;
    public Text text_pnl;
    public GameObject DelayPanel;
    public GameObject CustomSpeedPanel;


    private int points = -1;

    public void SetUiState()
    {
        if (pnl.activeSelf == false)
        {
            if (DelayPanel.activeSelf == false && CustomSpeedPanel.activeSelf == false)
            {
                pnl.SetActive(true);
            }

            if (CustomSpeedPanel.activeSelf == true)
            {
                CustomSpeedPanel.SetActive(false);

            }
            else if (DelayPanel.activeSelf == true)
            {
                DelayPanel.SetActive(false);
            }

         }
        else
        {
            pnl.SetActive(false);
        }
    }

    public void EditPoints()
    {
        points++;
        text_pnl.text = points.ToString();
        

    }

    public int ReturnScore()
    {
        return points;
    }
    public void EnableDelaySettings()
    {
        pnl.SetActive(false);
        DelayPanel.SetActive(true);
    }


    public void CutomDelayMenuEnable()
    {
        DelayPanel.SetActive(false);
        CustomSpeedPanel.SetActive(true);
    }


}

