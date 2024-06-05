using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;

    void Start()
    {
        SaveController.Instance.Reset();

        string lasWinner = SaveController.Instance.GetLastWinner();

        if (string.IsNullOrEmpty(lasWinner))
        {
            uiWinner.text = "";
        }
        else
        {
            uiWinner.text = "Último vencedor: " + lasWinner;
        }
    }
}
