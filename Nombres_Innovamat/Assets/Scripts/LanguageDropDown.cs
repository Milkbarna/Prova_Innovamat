using Assets.UIAnim_LIbrary.Scripts.Animations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageDropDown : MonoBehaviour
{
    [SerializeField]
    private Text currentText;
    [SerializeField]
    private GameObject[] langButtons;
    [SerializeField]
    private RectTransform dropDown;

    private bool visible;

    private GameController gc;

    [SerializeField]
    private AnimationCurve animLerp;
    private UIAnim anim;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
        currentText.text = Global.Instance.currentLanguage.ToString();

        anim = new ScaleAnim(dropDown);

        visible = false;

        langButtons[(int)Global.Instance.currentLanguage].SetActive(false);
    }

    public void Show()
    {
        visible = !visible;
        StartCoroutine(anim.Execute(animLerp, new Vector3(0, 1, 0), 0.2f, 0, visible, null));
    }

    public void ChangeTo(int lang)
    {
        Global.Instance.currentLanguage = (Language)lang;
        currentText.text = Global.Instance.currentLanguage.ToString();

        foreach (GameObject b in langButtons)
            b.SetActive(true);

        langButtons[(int)Global.Instance.currentLanguage].SetActive(false);

        Show();
        
        SceneManager.LoadScene("MainScene");
    }
}
