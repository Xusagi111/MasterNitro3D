using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AlphaChanger
{
    public static IEnumerator FadeTo(CanvasGroup canvasGroup, float aValue, float aTime)
    {
        float alpha = canvasGroup.alpha;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            canvasGroup.alpha = Mathf.Lerp(alpha, aValue, t);
            yield return null;
        }
        yield break;
    }
}
