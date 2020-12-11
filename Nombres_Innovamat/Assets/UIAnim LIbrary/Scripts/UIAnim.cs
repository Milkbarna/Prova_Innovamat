using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void NextFunctionDelegate();

public interface UIAnim
{
    IEnumerator Execute();

    IEnumerator Execute(AnimationCurve animCurve, float size, float duration, float delayAfter, bool forward, NextFunctionDelegate nextFunction);
}