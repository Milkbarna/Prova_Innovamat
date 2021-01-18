using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformReseter : MonoBehaviour
{

    [SerializeField]
    private RectTransform rectTransform;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = rectTransform.localScale;
    }

    public void SetOriginalSize()
    {
        rectTransform.localScale = originalScale;
    }
}
