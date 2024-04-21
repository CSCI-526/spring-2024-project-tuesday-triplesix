using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TwoBeatPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D _boxCollider2D;
    private TilemapCollider2D _tilemapCollider2D;
    private Material rendererMaterial;
    public float bpm = 120f;
    public string fmt = "0001";
    public float transparency = 0.2f;
    private float beatInterval;
    private float timer = 0f;
    public int beatCount = 0;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        beatInterval = 60f / bpm;
        rendererMaterial = renderer.material;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _tilemapCollider2D = GetComponent<TilemapCollider2D>();
        if (_tilemapCollider2D.gameObject.CompareTag("Platform1"))
        {
            Change(_tilemapCollider2D, rendererMaterial);
        }
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        int nBeats = fmt.Length;
        if (timer >= beatInterval)
        {
            timer -= beatInterval;
            beatCount++;
            Move(_tilemapCollider2D, rendererMaterial, fmt[beatCount % nBeats]);
        }
    }
    
    public void Move(TilemapCollider2D tileCollider2D, Material material, char position)
    {
        if (position == '1') {
            Change(tileCollider2D, material);
        }
    }

    private void Change(TilemapCollider2D tileCollider2D, Material material)
    {
        
        tileCollider2D.enabled = !tileCollider2D.enabled;
        var color = material.color;
        if (tileCollider2D.enabled == false)
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
