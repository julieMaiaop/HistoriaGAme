using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent OnPlayerKillEnemy;
    public UnityEvent OnPause;
    public UnityEvent OnUnPause;

    public int score;
    public int life = 3;
    public int lifeMax;
    public GameObject bullet;
    public Transform foot;
    bool groundCheck;
    public float speed = 5, jumpStrength = 5, bulletSpeed = 8;
    float horizontal;
    public Rigidbody2D body;

    Collider2D footCollision;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        lifeMax = life;
    }

    // Update is called once per frame
    void Update() 
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        //groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);
        footCollision = Physics2D.OverlapCircle(foot.position, 0.05f);
        groundCheck = footCollision;
        if(footCollision != null)
        {
            if (footCollision.CompareTag("Enemy"))
            {
                //Mathf.Pow(2, 5);//2 � elevado a 5
                //Mathf.PI;
                //Mathf.Infinity;
                body.AddForce(new Vector2(0, jumpStrength * 150));
                Destroy(footCollision.gameObject);
                OnPlayerKillEnemy.Invoke();//Aqui aciona o evento
            }
        }


        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.AddForce(new Vector2(0, jumpStrength * 100));
        }
        if(horizontal != 0)//Para GetAxisRaw
        {
            direction = (int)horizontal;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction, 0);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
                OnUnPause.Invoke();
            } else if(Time.timeScale == 1)//O jogo est� ocorrendo?
            {//Pause
                Time.timeScale = 0;
                OnPause.Invoke();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //life--;
            //life -= 1;
            //life = life -1;
            life -= collision.gameObject.GetComponent<Enemy>().damage;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.CompareTag("Coin"))
        {
            score += 5;//score = score +5;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Divisor"))
        {
            score /= 2;//score = score / 2;
            Destroy(collision.gameObject);
        }
        */
        switch (collision.tag)
        {
            case "Coin":
                //Aqui � o efeito do Coin
                score += 5;//score = score +5;
                Destroy(collision.gameObject);
                break;
            case "Divisor":
                //Aqui � o efeito do Divisor
                score /= 2;//score = score / 2;
                Destroy(collision.gameObject);
                break;
            default:

                break;
            
        }
    }
    void Teste()
    {
        print("Funcionou");
    }
}
