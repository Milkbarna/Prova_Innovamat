using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.UIAnim_LIbrary.Scripts.Animations;

public abstract class DropDown : MonoBehaviour
{
    [SerializeField]
    private Text currentText;
    [SerializeField]
    private GameObject[] buttons;
    [SerializeField]
    private RectTransform dropDown;

    private bool visible;

    [SerializeField]
    private AnimationCurve animLerp;
    private UIAnim anim;

    private void Start()
    {
        currentText.text = GetMainText();

        anim = new ScaleAnim(dropDown);

        visible = false;

        buttons[GetUnactivePos()].SetActive(false);
    }

    public void Show()
    {
        visible = !visible;
        StartCoroutine(anim.Execute(animLerp, new Vector3(0, 1, 0), 0.2f, 0, visible, null));
    }

    protected abstract int GetUnactivePos();

    protected abstract string GetMainText();

    public abstract void ChangeTo(int elem);
}
