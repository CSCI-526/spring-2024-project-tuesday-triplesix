using UnityEngine;

public class RectangleAnimation : MonoBehaviour
{
    public float flattenDuration = 1f;
    public float restoreDuration = 1f;

    private Vector3 originalScale;
    private bool isFlattened = false;

    void Start()
    {
        originalScale = transform.localScale;
        // start loop
        InvokeRepeating("Animate", 1f, flattenDuration + restoreDuration);
    }

    void Animate()
    {
        if (isFlattened)
        {
            LeanTween.scaleY(gameObject, originalScale.y, restoreDuration)
                .setEaseInOutQuad();
        }
        else
        {
            LeanTween.scaleY(gameObject, 0f, flattenDuration)
                .setEaseInOutQuad();
        }
        
        isFlattened = !isFlattened;
    }
}