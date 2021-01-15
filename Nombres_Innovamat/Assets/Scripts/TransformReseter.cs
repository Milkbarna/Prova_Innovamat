using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformReseter : MonoBehaviour
{

    private RectTransform rectTransform;
    private Vector3 originalScale;

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void SetOriginalSize()
    {
        rectTransform.localScale = originalScale;
    }
}
