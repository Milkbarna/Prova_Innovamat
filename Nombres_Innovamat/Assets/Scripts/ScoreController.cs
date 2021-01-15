using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Text resultsText;

    private int encerts, errors;

    void Start()
    {
        encerts = 0;
        errors = 0;

        resultsText = this.GetComponent<Text>();

        UpdateResults();
    }

    public void AddCorrect()
    {
        encerts++;
        UpdateResults();
    }

    public void AddError()
    {
        errors++;
        UpdateResults();
    }

    private void UpdateResults() //[TO DO]: if we have more text this should be done through a translation csv
    {
        switch (LanguageSingleton.Instance.currentLanguage)
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
}
