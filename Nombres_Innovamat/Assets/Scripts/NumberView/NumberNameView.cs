using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberNameView : NumberView
{
    public override void Display()
    {
        text.text = numInfo.text;
    }
}
