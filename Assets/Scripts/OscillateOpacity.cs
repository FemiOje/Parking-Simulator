using System.Collections;
using UnityEngine;

public class OscillateOpacity : MonoBehaviour
{
    public float minOpacity = 0.0f;
    public float maxOpacity = 1.0f;
    public float oscillationTime = 1.0f;

    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        StartCoroutine(Oscillate());
    }

    private IEnumerator Oscillate()
    {
        while (true)
        {
            for (float t = 0; t < 1; t += Time.deltaTime / oscillationTime)
            {
                float opacity = Mathf.Lerp(minOpacity, maxOpacity, t);
                SetOpacity(opacity);
                yield return null;
            }

            for (float t = 0; t < 1; t += Time.deltaTime / oscillationTime)
            {
                float opacity = Mathf.Lerp(maxOpacity, minOpacity, t);
                SetOpacity(opacity);
                yield return null;
            }
        }
    }

    private void SetOpacity(float opacity)
    {
        Color color = material.color;
        color.a = opacity;
        material.color = color;
    }
}