using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCheck : MonoBehaviour
{
    private int num;
    public GameObject click_call;

    public int field(Vector2 position)
    {
        if (position.x < 0 && position.y > 0 && position.y < 3.98 || position.x < 0 && position.x > -3.44  && position.y > 0)
        {

            return 1;
        }

        if (position.x > 0  && position.y > 0)
        {
            return 2;
        }

        if (position.x < 0  && position.y < 0)
        {
            return 3;
        }
        
        if (position.x > 0  && position.y < 0)
        {
            return 4;
        }


        return -1;
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            num = field(mousePosition);
            if (num != -1)
            {
                StartCoroutine(click_call.GetComponent<ColorPicker>().onclick(num));

                click_call.GetComponent<ColorPicker>().glow(num);
            }
            


        }
    }


}
