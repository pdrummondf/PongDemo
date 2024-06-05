using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckCPUController : MonoBehaviour
{
    public Toggle chkboxCPU;
    public TMP_InputField fieldEnemyName;

    public void OnToggleChanged()
    {
        SaveController.Instance.cpuAtivo = chkboxCPU.isOn;
        fieldEnemyName.interactable = !chkboxCPU.isOn;
        fieldEnemyName.text = chkboxCPU.isOn ? "CPU" : ""; 
    }
}
