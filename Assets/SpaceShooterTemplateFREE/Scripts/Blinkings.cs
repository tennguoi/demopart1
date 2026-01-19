using UnityEngine;

public class Blinkings : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRender spriteRender
    void Start()
    {
        spriteReder = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteReder.enable = !spriteReder.enable;

    }
}
