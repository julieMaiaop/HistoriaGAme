using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int healAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {//Criei abaixo um objeto que recebe o que colidiu com o lifepack
            Player hero = collision.gameObject.GetComponent<Player>();
            if (hero.life < hero.lifeMax)//A vida atual é menor que a vida máxima?
            {
                hero.life += healAmount;//Cure o jogador
                if(hero.life > hero.lifeMax)//Vish, o jogador tá com vida maior que a máxima
                {
                    hero.life = hero.lifeMax;//Reponha a vida para ser igual a máxima
                }
                Destroy(gameObject);//Destrua o pack de cura pois dentro desse if ele foi coletado
            }

        }

    }
}
