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
    private Vector3 originalScale;

    void Start()
    {
        
        gc = FindObjectOfType<GameController>();
        text = this.GetComponent<Text>();
        rectTransform = this.GetComponent<RectTransform>();

        originalScale = rectTransform.localScale;

        anim = new ScaleAnim(rectTransform);
    }

    public void DisplayNumber(NumInfo info)
    {
        text.text = info.text;
        StartCoroutine(anim.Execute(animLerp, new Vector3(1, 1, 1), 2, 2, true, HideNumber));
    }

    public void HideNumber()
    {
        StartCoroutine(anim.Execute(animLerp, new Vector3(1, 1, 1), 2, 0, false, gc.DisplayOptions));
    }

    public void SetOriginalSize()
    {
        rectTransform.localScale = originalScale;
    }
}
