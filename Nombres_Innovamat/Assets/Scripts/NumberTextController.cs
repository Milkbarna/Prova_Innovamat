using Assets.UIAnim_LIbrary.Scripts.Animations;
using UnityEngine;
using UnityEngine.UI;

public class NumberTextController : MonoBehaviour
{
    [SerializeField]
    private GameController gc;

    private NumberView view;

    void Start()
    {        
        view = this.GetComponent<NumberView>();
    }

    public void DisplayNumber(NumInfo info)
    {
        view.Set(info);
        view.Display();
        view.Show(HideNumber);
    }

    public void HideNumber()
    {
        view.Hide(gc.DisplayOptions);
    }
}
