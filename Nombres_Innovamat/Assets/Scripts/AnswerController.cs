using Assets.UIAnim_LIbrary.Scripts.Animations;
using UnityEngine;
using UnityEngine.UI;

public class AnswerController : MonoBehaviour
{
    [SerializeField]
    private Text text;
    private Button button;
    private Image image;
    private RectTransform rectTransform;

    [SerializeField]
    private AnimationCurve animLerp;
    private UIAnim anim;
    
    private GameController gc;

    [HideInInspector]
    public NumInfo num;

    private bool on;

    private Vector3 originalScale;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
        rectTransform = this.GetComponent<RectTransform>();
        button = this.GetComponent<Button>();
        image = this.GetComponent<Image>();

        button.enabled = false;
        image.color = Color.white;
        originalScale = rectTransform.localScale;

        anim = new ScaleAnim(rectTransform);

        on = false;
    }

    public void DisplayNumber(NumInfo info)
    {
        num = info;
        button.enabled = false;
        image.color = Color.white;

        text.text = info.num.ToString();
        on = true;
        StartCoroutine(anim.Execute(animLerp, new Vector3(1, 1, 1), 1, 0, true, EnableButton));
    }

    public void EnableButton()
    {
        button.enabled = true;
    }

    public void DisableButton()
    {
        button.enabled = false;
    }

    public void HideNumber()
    {
        if (on)
        {
            button.enabled = false;
            on = false;
            StartCoroutine(anim.Execute(animLerp, new Vector3(1,1,1), 1, 0, false, null));
        }
        
    }

    public void AnswerClick()
    {
        gc.Answer(this);
    }

    public void DisplayColor(Color color)
    {
        image.color = color;
    }

    public bool IsOn()
    {
        return on;
    }

    public void SetOriginalSize()
    {
        rectTransform.localScale = originalScale;
        on = false;
    }
}
