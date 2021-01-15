using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionCaller
{
    public IEnumerator CallFunctionAfterDelay(float delay, NextFunctionDelegate nextFunction) //Calls a function after a delay
    {
        yield return new WaitForSeconds(delay);

        //call next function (making sure there is one)
        if (nextFunction != null)
            nextFunction();
    }
}
