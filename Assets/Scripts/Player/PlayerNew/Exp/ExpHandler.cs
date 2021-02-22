using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpHandler
{
    private IExp dataController;
    public ExpHandler(IExp expDataController)
    {
        this.dataController = expDataController;
    }

    public int RewriteExpData(int inputExp)
    {
        var tempExpData = dataController.GetExpData();
        int levelsUp = 0;
        if (CheckInputExp(inputExp, tempExpData.CurrentExp))
        {
            tempExpData.CurrentExp += inputExp;
            while (tempExpData.CurrentExp >= tempExpData.ReqExp)
            {
                tempExpData.CurrentExp -= tempExpData.ReqExp;
                levelsUp++;
                tempExpData.Level++;
                tempExpData.ReqExp = IncreaseRequiredExp(tempExpData.ReqExp);
            }
            dataController.RewriteExpData(tempExpData);
        }

        return levelsUp;
    }
    public ExpData GetData()
    {
        return dataController.GetExpData();
    }
    private bool CheckInputExp(int input, int currentExp)
    {
        bool temp = false;
        if (input > 0)
        {
            if (input + currentExp > 0)
            {
                if (input + currentExp > currentExp)
                    temp = true;
                else
                {
                    Debug.LogError("Player exp value has been overloaded");
                    temp = false;
                } 
            }
            else
            {
                Debug.LogError("Player exp value has been overloaded");
                temp = false;
            }
        }
        else
        {
            Debug.LogError("Input Exp from battle <= 0");
            temp = false;
        }
        return temp;
    }
    private int IncreaseRequiredExp(int ReqExp)
    {
        // Testing formula
        return ReqExp + ReqExp / 5;
    }

}

