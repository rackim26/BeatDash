using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed; 
    Vector2 direction; 

    Rigibody2D rb; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigibody2D>(); 
        direction = Vector2.one.normalized; 
    }

    private void FixedUpdate() {
        rb.velocity = direction * speed; 
    }

    // Update is called once per frame
    
}
