using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class ButtonBar : MonoBehaviour
{
    public Color normalColor;
    public Color normalColorText;
    public Color selectedColor;
    public Button[] buttons;

    public void SelectButton(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TMP_Text>().color = normalColorText;
            buttons[i].transform.GetChild(1).GetComponent<ProceduralImage>().color = normalColor;
        }

        buttons[index].GetComponentInChildren<TMP_Text>().color = selectedColor;
        buttons[index].transform.GetChild(1).GetComponent<ProceduralImage>().color = selectedColor;
    }
}
