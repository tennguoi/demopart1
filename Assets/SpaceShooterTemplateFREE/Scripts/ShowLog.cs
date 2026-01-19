using UnityEngine;

public class ShowLog : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.log("Hello, World!");
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.log("Frame updated" + Time.frameCount);

    }
}
