using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject explosionPrefab;
    public int defaultHealthPoint;
    private int healthPoint;

    public void OnTriggerEnter2D(Collider2D collision) => Die();
    private void Start() => healthPoint = defaultHealthPoint;


    protected virtual void Die()
    {
        var explosion = Instantiate(explosionPrefab, transform.position,
        transform.rotation);
        Destroy(explosion, 1);
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;
        if (healthPoint <= 0) Die();
    }
}
