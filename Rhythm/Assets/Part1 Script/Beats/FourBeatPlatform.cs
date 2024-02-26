using System.Collections;
using UnityEditor;
using UnityEngine;

public class FourBeatPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D _boxCollider2D;
    public float timeInterval = 1f;
    public float transparency = 0.5f;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material rendererMaterial = renderer.material;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(PlatformRoutine(_boxCollider2D, rendererMaterial));
    }
    
    public IEnumerator PlatformRoutine(BoxCollider2D boxCollider2D, Material material)
    {
        var gameObj = boxCollider2D.gameObject;
        var flag2 = 0;
        var flag3 = 0;
        var flag4 = 0;
        while (true)
        {
            if (gameObj.CompareTag("Platform3"))
            {
                Change(boxCollider2D, material);
                // disable the collider, change the transparency of the material
                
            }
            else if (gameObj.CompareTag("Platform4"))
            {
                // a different beat
                if (flag2 == 0)
                {
                    yield return new WaitForSeconds(1f); // wait
                    flag2 = 1;
                }
                Change(boxCollider2D, material);

            }
            else if (gameObj.CompareTag("Platform5"))
            {
                if (flag3 == 0)
                {
                    yield return new WaitForSeconds(2f); // wait
                    flag3 = 1;
                }
                // a different beat
                Change(boxCollider2D, material);
            }
            else if (gameObj.CompareTag("Platform6"))
            {
                if (flag4 == 0)
                {
                    yield return new WaitForSeconds(3f); // wait
                    flag4 = 1;
                }
                // a different beat
                Change(boxCollider2D, material);
            }
        }
    }

    private void Change(BoxCollider2D boxCollider2D, Material material)
    {
        
        boxCollider2D.enabled = !boxCollider2D.enabled;
        var color = material.color;
        if (boxCollider2D.enabled == false)
        {
            color.a = transparency;
            material.color = color;
        }
        else
        {
            color.a = 1;
            material.color = color;
        }
    }
}

