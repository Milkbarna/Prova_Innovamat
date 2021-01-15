using Assets.UIAnim_LIbrary.Scripts.Animations;
using UnityEngine;
using UnityEngine.UI;

public class AnswerController : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private GameController gc;

    [HideInInspector]
    public NumInfo num;

    private bool on;

    private NumberView view;

    void Start()
    {
        button = this.GetComponent<Button>();
        view = this.GetComponent<NumberView>();

        button.enabled = false;
        view.ChangeColor(Color.white);

        on = false;
    }

    public void DisplayNumber(NumInfo info)
    {
        num = info;
        button.enabled = false;

        view.Set(info);
        view.Display();
        view.ChangeColor(Color.white);

        on = true;

        view.Show(EnableButton);
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
            view.Hide();
        }
    }

    public void AnswerClick()
    {
        gc.Answer(this);
    }

    public bool IsOn()
    {
        return on;
    }

    public void DisplayAsCorrect()
    {
        view.ChangeColor(Color.green);
        HideNumber();
    }

    public void DisplayAsError()
    {
        view.ChangeColor(Color.red);
        HideNumber();
    }
}
