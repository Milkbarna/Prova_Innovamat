using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.UIAnim_LIbrary.Scripts.Animations;

public abstract class NumberView : MonoBehaviour
{
    [SerializeField]
    protected Text text;
    [SerializeField]
    protected Image image;

    [SerializeField]
    private AnimationCurve animLerp;
    private UIAnim anim;

    protected NumInfo numInfo;

    [SerializeField]
    private Vector3 growSize;
    [SerializeField]
    private float duration = 1;
    [SerializeField]
    private float delayAfter = 1;

    void Start()
    {
        anim = new ScaleAnim(this.GetComponent<RectTransform>());
    }

    public void Set(NumInfo info)
    {
        numInfo = info;
    }

    public abstract void Display(); //Display number name, digit, images, ...

    public void Show()
    {
        StartCoroutine(anim.Execute(animLerp, growSize, duration, 0, true, null));
    }

    public void Show(NextFunctionDelegate nextFunction)
    {
        StartCoroutine(anim.Execute(animLerp, growSize, duration, delayAfter, true, nextFunction));
    }

    public void Hide()
    {
        StartCoroutine(anim.Execute(animLerp, growSize, duration, delayAfter, false, null));
    }

    public void Hide(NextFunctionDelegate nextFunction)
    {
        StartCoroutine(anim.Execute(animLerp, growSize, duration, delayAfter, false, nextFunction));
    }     

    public void ChangeColor(Color color)
    {
        if (image != null)
            image.color = color;
    }
}
