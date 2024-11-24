using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class HeartSystem : MonoBehaviour
{
    private string Player1 = "NinjaFrog"; //Referencia o objeto com o nome de NinjaFrog
    private string Player2 = "PinkMan"; //Referencia o objeto com o nome de PinkMan
    
    public int life; //Define a vida atual
    public int lifeMax; //Define a vida máxima

    public Image[] heart; //Define um array de imagens
    public Sprite breakHeart; //Um sprite (Imagem) para o coração quebrado
    public Sprite fullHeart; //Um sprite (Imagem) para o coração cheio

    public Image NinjaFrogDeath;
    public Image PinkManDeath;

    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;

    private void Awake()
    {
        NinjaFrogDeath = GameObject.Find("NinjaFrogImage").GetComponent<Image>(); //Pega a imagem do NinjaFrog na UI e atribui para essa variavel do tipo imagem
        PinkManDeath = GameObject.Find("PinkManImage").GetComponent<Image>(); //Pega a imagem do PinkMan na UI e atribui para essa variavel do tipo imagem
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic(); //Chama o método de vida
        DeathState(); //Chama o método de morte
    }

    void HealthLogic()
    {
        if (life > lifeMax) //Verifica se o valor da vida atual é maior que a vida máxima
        {
            life = lifeMax;
        }
        
        for (int i = 0; i < heart.Length; i++)
        {
            if(i < life)
            {
                heart[i].sprite = fullHeart;
            }
            else
            {
                heart[i].sprite = breakHeart;
            }
            
            if (i < lifeMax)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }

        }

    }

    public void KillDamage()
    {
        life = 0;
        heart[1].sprite = breakHeart;
        heart[2].sprite = breakHeart;
        heart[3].sprite = breakHeart;
        DeathState();
    }

    public void DeathState()
    {
        if (life <= 0)
        {

            GameObject objNinjaFrog = GameObject.Find(Player1); //Atribui a variavel do tipo GAMEOBJECT o nome do objeto referente ao player, para poder fazer a condição necessária
            GameObject objPinkMan = GameObject.Find(Player2);

            if (gameObject.name == Player1) //Se o NinjaFrog chegar a 0 de vida ou menos, ele será destruido
            {
                objNinjaFrog.SetActive(false);
                Debug.Log("Objeto destruido1");
                NinjaFrogDeath.color = Color.red; //Muda a cor da imagem para vermelho
                Destroy(objNinjaFrog); //Destroi o objeto NinjaFrog
                camera1.SetActive(false);
                camera3.SetActive(true);
            }

            if (gameObject.name == Player2) //Se o PinkMan chegar a 0 de vida ou menos, ele será destruido
            {
                objPinkMan.SetActive(false);
                Debug.Log("Objeto destruido2");
                PinkManDeath.color = Color.red;  //Muda a cor da imagem para vermelho
                Destroy(objPinkMan); //Destroi o objeto PinkMan
                camera1.SetActive(false);
                camera2.SetActive(true);
            }

        }
    }

}
