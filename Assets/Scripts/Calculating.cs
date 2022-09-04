using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculating : MonoBehaviour
{
    int result;
    string operatorValue;
    string num1, num2, showingNum;
    ResultUpdate resUpd;

    private void Start()
    {
        resUpd = GetComponent<ResultUpdate>();
        Load();
    }
    public void CalculateNumbs(string numValue)
    {
        if (operatorValue == null && Convert.ToInt32(num1 + numValue) <= Int32.MaxValue)
        {
            num1 += numValue;
            showingNum = num1;
        }
        else if (num1 != null && operatorValue != null && Convert.ToInt32(num2 + numValue) <= Int32.MaxValue)
        {
            num2 += numValue;
            showingNum = num2;
        }
        resUpd.TextUpdating(showingNum);
    }
    public void OperatorSign(string operatorInput)
    {
        if (num1 != null)
            operatorValue = operatorInput;

        resUpd.OperatorUpdating(operatorValue);
    }
    public void ClearingNums()
    {
        num1 = null;
        num2 = null;
        result = 0;
        operatorValue = null;
        resUpd.TextUpdating(null);
        resUpd.OperatorUpdating(null);
    }

    public void Result()
    {
        switch (operatorValue)
        {
            case "+":
                result = Convert.ToInt32(num1) + Convert.ToInt32(num2);
                break;
            case "-":
                result = Convert.ToInt32(num1) - Convert.ToInt32(num2);
                break;
            case "*":
                result = Convert.ToInt32(num1) * Convert.ToInt32(num2);
                break;
            case "/":
                result = Convert.ToInt32(num1) / Convert.ToInt32(num2);
                break;
        }
        if (result<0|| result>=Int32.MaxValue )
        {
            result = 0;
        }
        resUpd.TextUpdating(result.ToString());
        resUpd.OperatorUpdating(null);
        operatorValue = null;
        num1 = result.ToString();
        result = 0;
        num2 = null;
     //   result = 0;
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("num1", num1);
        PlayerPrefs.SetString("num2", num2);
        PlayerPrefs.SetString("oper", operatorValue);
     //   PlayerPrefs.SetString("res", result.ToString());
    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("num1"))
        {
            num1 = PlayerPrefs.GetString("num1");
            resUpd.TextUpdating(num1);
            print(num1 + " num1");
            if (PlayerPrefs.HasKey("oper") && num1 != "")
            {
                operatorValue = PlayerPrefs.GetString("oper");
                resUpd.OperatorUpdating(operatorValue);
                print(operatorValue + " oper");
                if (PlayerPrefs.HasKey("num2") && operatorValue != "")
                {
                    num2 = PlayerPrefs.GetString("num2");
                    if(num2 != "")
                    {
                        resUpd.TextUpdating(num2);
                    }
                    print(num2 + " num2");
                }
            }
        }
    }
}
