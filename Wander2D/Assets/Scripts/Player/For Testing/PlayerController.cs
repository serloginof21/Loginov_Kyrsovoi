using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 8;
    public Vector2 direction;
    public Rigidbody2D rb;
    [SerializeField] public Animator animator;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);

        // if(Input.GetKeyDown(KeyCode.Escape)){
        //     SceneManager.LoadScene("MainMenu");
        // }
    }
    
    public void FixedUpdate() 
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);  
    }
}
