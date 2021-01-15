using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDigitView : NumberView
{
    public override void Display()
    {
        text.text = numInfo.num.ToString();
    }
}
