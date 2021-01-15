using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [Header("UI Elems")]
    [SerializeField]
    private ScoreController score;
    [SerializeField]
    private NumberTextController numText;
    [SerializeField]
    private AnswerController[] buttonAnswers;

    private FunctionCaller _functionCaller;
    private TaskLogic _taskLogic;

    void Start()
    {
        _functionCaller = new FunctionCaller(); //[TO DO]: Avoid "new" (D in SOLID)
        _taskLogic = new TaskLogic(); //[TO DO]: Avoid "new" (D in SOLID)
        _taskLogic.LoadNumbers();

        StartCoroutine(_functionCaller.CallFunctionAfterDelay(0.5f, GenerateTask)); //give time to read file
    }

    public void GenerateTask()
    {
        //Call animation to show and hide number        
        numText.DisplayNumber(_taskLogic.GetTaskNum());
    }

    public void DisplayOptions()
    {
        List<NumInfo> options = _taskLogic.GetOptions(buttonAnswers.Length + 1);

        //Add options to buttons
        for (int i = 0; i< buttonAnswers.Length; i++)
        {
            buttonAnswers[i].DisplayNumber(options[i]);
        }
    }

    public void Answer(AnswerController button)
    {
        DisableAllAnswers();

        //Check if it's correct
        if (_taskLogic.isCorrect(button.num))
        {
            button.DisplayAsCorrect();
            score.AddCorrect();

            foreach (AnswerController answer in buttonAnswers)
            {
                answer.HideNumber();
            }

            //generate the next taks after a short delay
            StartCoroutine(_functionCaller.CallFunctionAfterDelay(1.2f, GenerateTask));
        }
        else
        {
            button.DisplayAsError();
            score.AddError();

            List<AnswerController> aviableAnswers = AviableAnswers();

            if (aviableAnswers.Count == 1) //if there is only one answer left reaveal it and hide it
            {
                if (aviableAnswers[0] != null)
                    aviableAnswers[0].DisplayAsCorrect();

                //generate the next taks after a short delay
                StartCoroutine(_functionCaller.CallFunctionAfterDelay(1.2f, GenerateTask));
            }
            else
            {
                StartCoroutine(_functionCaller.CallFunctionAfterDelay(1, EnableAllAnswers));
            }

        }
    }

    private void DisableAllAnswers()
    {
        foreach (AnswerController answer in buttonAnswers)
        {
            answer.DisableButton();
        }
    }

    private void EnableAllAnswers()
    {
        foreach (AnswerController answer in buttonAnswers)
        {
            answer.EnableButton();
        }
    }

    private List<AnswerController> AviableAnswers()
    {
        List<AnswerController> aviableAnswers = new List<AnswerController>();

        foreach (AnswerController answer in buttonAnswers)
            if (answer.IsOn())
                aviableAnswers.Add(answer);

        return aviableAnswers;
    }
}
