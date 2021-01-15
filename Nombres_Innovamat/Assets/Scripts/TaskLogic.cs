using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskLogic
{
    private List<NumInfo> nummeros;
    private NumInfo currentNum;

    public NumInfo GetTaskNum()
    {
        int randIndex = Random.Range(0, nummeros.Count);

        //control not to reapeat the same number twice in a row, can be repeated later
        NumInfo newNum = GetRandomNumInfo();
        while (newNum.num == currentNum.num)
            newNum = GetRandomNumInfo();

        currentNum = newNum;
        return currentNum;
    }

    private NumInfo GetRandomNumInfo() //Get one random number from nummeros
    {
        int randIndex = Random.Range(0, nummeros.Count);
        return nummeros[randIndex];
    }

    public List<NumInfo> GetOptions(int numOptions)
    {
        List<NumInfo> options = new List<NumInfo>();

        //Generate random numbers different from current
        options.Add(currentNum); //we add the correct answer to make sure we do not reapet it
        while (options.Count < numOptions)
        {
            NumInfo n = GetRandomNumInfo();
            if (!options.Contains(n)) //We only add a number if it's not in the list
                options.Add(n);
        }
        options.RemoveAt(0); //remove the correct answer from the first position

        //Replace one random option with the correct number
        int randIndex = Random.Range(0, options.Count);
        options[randIndex] = currentNum;

        return options;
    }

    public bool isCorrect(NumInfo numInfo)
    {
        return (numInfo.num == currentNum.num);
    }

    public void LoadNumbers()
    {
        NumCSVLoader numLoader = new NumCSVLoader();
        nummeros = numLoader.LoadNumbers();
    }

}
