using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
{
    public Transform objetoAlvo; // Referência ao objeto que será o alvo da rotação
    public float velocidadeRotacao = 5f; // Velocidade de rotação do objeto

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 1f; // Intervalo de tempo entre os disparos
    private float shootTimer = 0f; // Temporizador para controlar o intervalo de tiro

    public float life;

    void Update()
    {
        if (objetoAlvo != null)
        {
            Vector2 direcao = objetoAlvo.position - transform.position;
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            Quaternion rotacaoDesejada = Quaternion.AngleAxis(angulo, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoDesejada, velocidadeRotacao * Time.deltaTime);

            shootTimer += Time.deltaTime;

            if (shootTimer >= shootInterval)
            {
                Shoot();
                shootTimer = 0f;
            }
        }

        if(life <= 0)
        {
            Destroy();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objetoAlvo = collision.transform;
        }
    }

    void Shoot()
    {
        // Criação do projetil
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
