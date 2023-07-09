using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
{
    public Transform objetoAlvo; // Refer�ncia ao objeto que ser� o alvo da rota��o
    public float velocidadeRotacao = 5f; // Velocidade de rota��o do objeto

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 1f; // Intervalo de tempo entre os disparos
    private float shootTimer = 0f; // Temporizador para controlar o intervalo de tiro

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objetoAlvo = other.transform;
        }
    }

    void Shoot()
    {
        // Cria��o do projetil
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


}
