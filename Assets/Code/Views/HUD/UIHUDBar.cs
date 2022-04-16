using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHUDBar : MonoBehaviour 
{
    [SerializeField] Image imageBar = null;

    public void UpdateHealthBar(float parameter)
    {
        imageBar.fillAmount = parameter;
    }
}