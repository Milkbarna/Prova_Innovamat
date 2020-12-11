using Assets.UIAnim_LIbrary.Scripts.Animations;
using UnityEngine;
using UnityEngine.UI;

public class NumberTextController : MonoBehaviour
{
    private Text text;
    private RectTransform rectTransform;

    [SerializeField]
    private AnimationCurve animLerp;
    private UIAnim anim;

    private GameController gc;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
        text = this.GetComponent<Text>();
        rectTransform = this.GetComponent<RectTransform>();

        anim = new ScaleAnim(rectTransform);
    }

    public void DisplayNumber(NumInfo info)
    {
        text.text = info.text;
        StartCoroutine(anim.Execute(animLerp, 1, 2, 2, true, HideNumber));
    }

    public void HideNumber()
    {
        StartCoroutine(anim.Execute(animLerp, 1, 2, 0, false, gc.DisplayOptions));
    }
}
