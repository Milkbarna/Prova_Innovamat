using Assets.UIAnim_LIbrary.Scripts.Animations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageDropDown : DropDown
{
    protected override int GetUnactivePos()
    {
        return (int)LanguageSingleton.Instance.currentLanguage;
    }

    protected override string GetMainText()
    {
        return LanguageSingleton.Instance.currentLanguage.ToString();
    }

    public override void ChangeTo(int elem) {
        LanguageSingleton.Instance.currentLanguage = (Language)elem;

        SceneManager.LoadScene("MainScene");
    }
}
