using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text resultsText;

    private int encerts, errors;

    void Start()
    {
        encerts = 0;
        errors = 0;

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
            case LanguageType.CAT:
                resultsText.text = "Encerts: " + encerts + "\nErrades: " + errors;
                break;
            case LanguageType.ENG:
                resultsText.text = "Right: " + encerts + "\nWrong: " + errors;
                break;
            case LanguageType.ESP:
                resultsText.text = "Aciertos: " + encerts + "\nErrores: " + errors;
                break;
        }

    }
}
