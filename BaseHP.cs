using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseHP : MonoBehaviour
{
    public GameObject canvasGroup;
    public TMP_Text hpText;
    public static int baseHp = 3;

    private void Update()
    {
        hpText.text = baseHp.ToString();
        if(baseHp <= 0) // Number cap to 0
        {
            baseHp = 0;
            hpText.text = baseHp.ToString(); 
        }
        canvasGroup.SetActive(true);
    }

}
