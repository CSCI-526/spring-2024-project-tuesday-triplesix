using System.Collections;
using UnityEditor;
using UnityEngine;

public class FourBeatPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D _boxCollider2D;
    private float appearInterval = 3.7f; // the beat
    public float transparency = 0.5f;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material rendererMaterial = renderer.material;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        Change(_boxCollider2D, rendererMaterial);
        StartCoroutine(PlatformRoutine(_boxCollider2D, rendererMaterial));
    }
    
    public IEnumerator PlatformRoutine(BoxCollider2D boxCollider2D, Material material)
    {
        var gameObj = boxCollider2D.gameObject;
        var flag2 = 0;
        var flag3 = 0;
        var flag4 = 0;
        var flag5 = 0;
        var flag6 = 0;
        while (true)
        {
            if (gameObj.CompareTag("Platform3"))
            {
                Change(boxCollider2D, material);
                // disable the collider, change the transparency of the material
                yield return new WaitForSeconds(0.8f);
                Change(boxCollider2D, material);
                yield return new WaitForSeconds(appearInterval); // wait
            }
            else if (gameObj.CompareTag("Platform4"))
            {
                if (flag2 == 0)
                {
                    yield return new WaitForSeconds(0.8f);
                    flag2 = 1;
                }
                Change(boxCollider2D, material);
                // disable the collider, change the transparency of the material
                yield return new WaitForSeconds(0.8f);
                Change(boxCollider2D, material);
                yield return new WaitForSeconds(appearInterval); // wait
            }
            else if (gameObj.CompareTag("Platform5"))
            {
                if (flag3 == 0)
                {
                    yield return new WaitForSeconds(1.6f);
                    flag3 = 1;
                }
                Change(boxCollider2D, material);
                // disable the collider, change the transparency of the material
                yield return new WaitForSeconds(0.8f);
                Change(boxCollider2D, material);
                yield return new WaitForSeconds(appearInterval); // wait
            }
            else if (gameObj.CompareTag("Platform6"))
            {
                if (flag4 == 0)
                {
                    yield return new WaitForSeconds(2.4f);
                    flag4 = 1;
                }
                Change(boxCollider2D, material);
                // disable the collider, change the transparency of the material
                yield return new WaitForSeconds(0.8f);
                Change(boxCollider2D, material);
                yield return new WaitForSeconds(appearInterval); // wait
            }
            else if (gameObj.CompareTag("Platform7"))
            {
                if (flag5 == 0)
                {
                    yield return new WaitForSeconds(3.2f);
                    flag5 = 1;
                }
                Change(boxCollider2D, material);
                // disable the collider, change the transparency of the material
                yield return new WaitForSeconds(0.4f);
                Change(boxCollider2D, material);
                yield return new WaitForSeconds(appearInterval+0.4f); // wait
            }
            else if (gameObj.CompareTag("Platform8"))
            {
                if (flag6 == 0)
                {
                    yield return new WaitForSeconds(3.6f);
                    flag6 = 1;
                }
                Change(boxCollider2D, material);
                // disable the collider, change the transparency of the material
                yield return new WaitForSeconds(0.4f);
                Change(boxCollider2D, material);
                yield return new WaitForSeconds(appearInterval+0.4f); // wait
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

