using System.Collections;
using UnityEngine;

public class TwoBeatPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D _boxCollider2D;
    public float transparency = 0.5f;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material rendererMaterial = renderer.material;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(PlatformRoutine(_boxCollider2D, rendererMaterial));
    }

    private IEnumerator PlatformRoutine(BoxCollider2D boxCollider2D, Material material)
    {
        float appearInterval = 1f; // the beat
        var gameObj = boxCollider2D.gameObject; 
        while (true)
        {
            if (gameObj.CompareTag("Platform"))
            {
                yield return new WaitForSeconds(appearInterval); // wait
                // disable the collider, change the transparency of the material
                Change(boxCollider2D, material);
            }
            else if (gameObj.CompareTag("Platform1"))
            {
                // a different beat
                Change(boxCollider2D, material);
                yield return new WaitForSeconds(appearInterval); // wait
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
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
