using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Language language = Language.CAT;

    private NumInfo currentNum;
    private List<NumInfo> nummeros;

    [Header("UI Elems")]
    [SerializeField]
    private Text resultsText;
    [SerializeField]
    private NumberTextController numText;
    [SerializeField]
    private AnswerController[] buttonAnswers;

    private int encerts, errors;

    void Start()
    {
        encerts = 0;
        errors = 0;

        LoadNumbers(language);
        StartCoroutine(Global.Instance.CallFunctionAfterDelay(0.5f, GenerateTask)); //give time to read file
    }

    public void GenerateTask()
    {
        //control not to reapeat the same number twice in a row, can be repeated later
        NumInfo newNum = GetNumber(); 
        while (newNum.num == currentNum.num)
            newNum = GetNumber();

        currentNum = newNum;

        //Call animation to show and hide number        
        numText.DisplayNumber(currentNum);
    }

    private NumInfo GetNumber() //Get one random number from nummeros
    {
        int randIndex = Random.Range(0, nummeros.Count);
        return nummeros[randIndex];
    }

    public void DisplayOptions()
    {
        List<NumInfo> options = new List<NumInfo>();

        //Generate random numbers different from current
        options.Add(currentNum); //we add the correct answer to make sure we do not reapet it
        while (options.Count < buttonAnswers.Length + 1) //loop until we have as many numbers as answer buttons + the control correct number
        {
            NumInfo n = GetNumber();
            if (!Global.Instance.InList(options, n)) //We only add a number if it's not in the list
                options.Add(n);
        }
        options.RemoveAt(0); //remove the correct answer from the first position

        //Set one random option to the correct number
        int randIndex = Random.Range(0, options.Count);
        options[randIndex] = currentNum;

        //Add options to buttons
        for (int i = 0; i< buttonAnswers.Length; i++)
        {
            buttonAnswers[i].DisplayNumber(options[i]);
        }
    }

    public void Answer(AnswerController button)
    {
        //Disable answers
        foreach (AnswerController answer in buttonAnswers)
        {
            answer.DisableButton();
        }

        //Check if it's correct
        if (button.num.num == currentNum.num)
        {
            //paint green
            button.DisplayColor(Color.green);

            //add encert
            encerts++;
            UpdateResults();

            foreach (AnswerController answer in buttonAnswers)
            {
                answer.HideNumber();
            }

            //generate the next taks after a short delay
            StartCoroutine(Global.Instance.CallFunctionAfterDelay(1.2f, GenerateTask));
        }
        else
        {
            //paint red
            button.DisplayColor(Color.red);

            //add error
            errors++;
            UpdateResults();

            button.HideNumber();

            //check how many answers are left
            int aviableAnswers = 0;
            AnswerController lastAnswer = null;
            foreach (AnswerController answer in buttonAnswers)
            {
                if (answer.IsOn())
                {
                    aviableAnswers++;
                    lastAnswer = answer;
                }
                    
            }

            if (aviableAnswers == 1) //if there is only one answer left reaveal it and hide it
            {
                if (lastAnswer != null)
                    lastAnswer.DisplayColor(Color.green);

                lastAnswer.HideNumber();

                //generate the next taks after a short delay
                StartCoroutine(Global.Instance.CallFunctionAfterDelay(1.2f, GenerateTask));
            }
            else
            {
                foreach (AnswerController answer in buttonAnswers)
                {
                    if (answer.IsOn())
                        StartCoroutine(Global.Instance.CallFunctionAfterDelay(1, answer.EnableButton));
                }
            }

        }
    }

    private void LoadNumbers(Language lang)
    {
        language = lang;
        nummeros = new List<NumInfo>();

        TextAsset fileData = Resources.Load<TextAsset>("numbersData"); //we load the csv as a TextAsset from the Resources folder
        
        string[] lines = fileData.text.Split( new char[] { '\n' }); //separate the text into lines

        for (int x = 1; x < lines.Length-1; x++) //we skip the first line (headers)
        {
            string[] lineData = lines[x].Split (new char[] { ';' }); //we separate each data element or column

            NumInfo number = new NumInfo { num = int.Parse(lineData[0]), text = lineData[(int)lang + 1] }; //we save the information at the nummeros list
            nummeros.Add(number);
        }           
    }

    private void UpdateResults() //[TO DO]: if we have more text this should be done through a translation csv
    {
        switch (language)
        {
            case Language.CAT:
                resultsText.text = "Encerts: " + encerts + "\nErrades: " + errors;
                break;
            case Language.ENG:
                resultsText.text = "Right: " + encerts + "\nWrong: " + errors;
                break;
            case Language.ESP:
                resultsText.text = "Aciertos: " + encerts + "\nErrores: " + errors;
                break;
        }
        
    }

    public void ChangeLanguage(Language l)
    {
        language = l;

        StopAllCoroutines(); //We stop possible coroutines

        foreach (AnswerController answer in buttonAnswers)
        {
            answer.DisableButton(); //disable all buttons
            answer.SetOriginalSize(); //hide all buttons
        }
        numText.SetOriginalSize(); //hide question text

        encerts = 0; //reset score
        errors = 0;

        LoadNumbers(language); //load the numbers in new language
        StartCoroutine(Global.Instance.CallFunctionAfterDelay(0.5f, GenerateTask)); //start again
    }
}
