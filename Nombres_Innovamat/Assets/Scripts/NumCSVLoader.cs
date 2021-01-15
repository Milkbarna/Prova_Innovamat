using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCSVLoader
{
    public List<NumInfo> LoadNumbers()
    {
        List<NumInfo> nummeros = new List<NumInfo>();

        TextAsset fileData = Resources.Load<TextAsset>("numbersData"); //we load the csv as a TextAsset from the Resources folder

        string[] lines = fileData.text.Split(new char[] { '\n' }); //separate the text into lines

        for (int x = 1; x < lines.Length - 1; x++) //we skip the first line (headers)
        {
            string[] lineData = lines[x].Split(new char[] { ';' }); //we separate each data element or column

            NumInfo number = new NumInfo { num = int.Parse(lineData[0]), text = lineData[(int)LanguageSingleton.Instance.currentLanguage + 1] }; //we save the information at the nummeros list
            nummeros.Add(number);
        }

        return nummeros;
    }
}
