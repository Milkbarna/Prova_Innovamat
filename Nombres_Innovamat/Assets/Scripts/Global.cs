using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    private static Global instance;

    public Language currentLanguage;

    void Awake() //Do not destroy this GameObject
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static Global Instance //Get the instance or Singleton
    {
        get { return instance ?? (instance = new GameObject("GlobalSingleton").AddComponent<Global>()); }
    }

    public IEnumerator CallFunctionAfterDelay(float delay, NextFunctionDelegate nextFunction) //Calls a function after a delay
    {
        yield return new WaitForSeconds(delay);

        //call next function (making sure there is one)
        if (nextFunction != null)
            nextFunction();
    }

    public bool InList(List<NumInfo> numList, NumInfo n) //Check if a NumInfo is already in a NumInfo list
    {
        bool isHere = false;

        foreach (NumInfo n2 in numList)
            if (n2.num == n.num)
                isHere = true;

        return isHere;
    }
}


public struct NumInfo
{
    public string text;
    public int num;
}

public enum Language
{
    CAT,
    ESP,
    ENG
}