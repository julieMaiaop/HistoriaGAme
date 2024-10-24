using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformFall : MonoBehaviour
{
    Rigidbody2D rb;
    float fallDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   

    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.2f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, fallDelay );
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }

    }
}
