using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class BottomBar : MonoBehaviour
{
    public Color normalColor;
    public Color selectedColor;
    public Button[] buttons;

    public void SelectButton(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TMP_Text>().color = normalColor;
            buttons[i].GetComponent<ProceduralImage>().color = normalColor;
        }

        buttons[index].GetComponentInChildren<TMP_Text>().color = selectedColor;
        buttons[index].GetComponent<ProceduralImage>().color = selectedColor;
    }
}
