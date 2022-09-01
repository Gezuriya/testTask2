using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculating : MonoBehaviour
{
    int result, num1, num2, showingNum;
    string operatorValue;
    ResultUpdate resUpd;

    private void Start()
    {
        resUpd = GetComponent<ResultUpdate>();
    }

    public void CalculateNumbs(int numValue)
    {
        if (operatorValue == null)
        {
            num1 = numValue;
            showingNum = num1;
        }
        else if (num1 != 0 && operatorValue != null)
        {
            num2 = numValue;
            showingNum = num2;
        }

        print("num1 " + num1);
        print("num2 " + num2);
        resUpd.TextUpdating(showingNum.ToString());
    }
    public void OperatorSign(string operatorInput)
    {
        if (num1 != 0)
            operatorValue = operatorInput;
    }
    public void ClearingNums()
    {
        num1 = 0;
        num2 = 0;
        result = 0;
        resUpd.TextUpdating(null);
    }

    public void Result()
    {
        switch (operatorValue)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                result = num1 / num2;
                break;
        }
        resUpd.TextUpdating(result.ToString());
        operatorValue = null;
        num1 = 0;
        num2 = 0;
        result = 0;
    }
}
