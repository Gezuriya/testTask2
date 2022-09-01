using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultUpdate : MonoBehaviour
{
    public TextMeshProUGUI inputText;

    public void TextUpdating(string value)
    {
        inputText.text = value;
    }
    
}
