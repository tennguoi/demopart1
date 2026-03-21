using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public RectTransform mask;
    public Health health;

    private float originalWidth;

    void Start()
    {
        // Check mask assignment
        if (mask == null)
        {
            mask = GetComponent<RectTransform>();
            if (mask == null)
            {
                Debug.LogError("Mask RectTransform is not assigned and not found on this GameObject!", this);
                return;
            }
        }
        
        // Auto-find health component if not assigned
        if (health == null)
        {
            // Try to find health on this GameObject first
            health = GetComponent<Health>();
            
            // If not found, try on parent
            if (health == null && transform.parent != null)
            {
                health = GetComponentInParent<Health>();
            }
            
            // If still not found, try finding by tag (if your player has "Player" tag)
            if (health == null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    health = player.GetComponent<Health>();
                }
            }
            
            if (health == null)
            {
                Debug.LogError("Health component not found! Please assign it manually in the Inspector.", this);
                return;
            }
        }
        
        originalWidth = mask.sizeDelta.x;
        UpdateHealthValue();
        health.onHealthChanged += UpdateHealthValue;
    }

    private void UpdateHealthValue()
    {
        if (health == null || mask == null) return;
        
        float scale = (float)health.healthPoint / health.defaultHealthPoint;
        mask.sizeDelta = new Vector2(scale * originalWidth, mask.sizeDelta.y);
    }
    
    void OnDestroy()
    {
        if (health != null)
        {
            health.onHealthChanged -= UpdateHealthValue;
        }
    }
}