using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    Calculating calc;
    ResultUpdate resUpd;
    private void Start()
    {
        calc = GetComponent<Calculating>();
        resUpd = GetComponent<ResultUpdate>();
    }
    public void ClickNum(string value)
    {
        calc.CalculateNumbs(value);
        // resUpd.TextUpdating(value.ToString());
        // print(value);
    }

    public void OperatorClick(string value)
    {
        //    print(value);
        calc.OperatorSign(value);
    }

    public void Equals()
    {
        calc.Result();
    }

    public void Clear()
    {
        calc.ClearingNums();
    }
    public void ExitButton()
    {
        calc.Save();
        Application.Quit();
    }
}
