using System.Collections;
using UnityEngine;

public class TwoBeatPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D _boxCollider2D;
    public float transparency = 0.5f;
    public float beat1 = 1f; // the beat
    public float beat2 = 0.1f;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material rendererMaterial = renderer.material;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        if (_boxCollider2D.gameObject.CompareTag("Platform1"))
        {
            Change(_boxCollider2D, rendererMaterial);
        }
        StartCoroutine(PlatformRoutine(_boxCollider2D, rendererMaterial));
    }

    private IEnumerator PlatformRoutine(BoxCollider2D boxCollider2D, Material material)
    {
        
        var gameObj = boxCollider2D.gameObject; 
        while (true)
        {
            yield return new WaitForSeconds(beat1); // wait
            // disable the collider, change the transparency of the material
            Change(boxCollider2D, material);  //dark
            yield return new WaitForSeconds(beat2);// wait
            // disable the collider, change the transparency of the material
            Change(boxCollider2D, material);  //light
            yield return new WaitForSeconds(0.01f);// wait
            Change(boxCollider2D, material);  //dark
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
