using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleControler : MonoBehaviour
{
    public float speed = 5f;

    public string movementAxisName;

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    private GameObject ball;

    private void Start()
    {
        if (isPlayer)
        {
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveController.Instance.colorEnemy;
            ball = GameObject.Find("Ball");
        }
    }

    void Update()
    {
        // Captura da entrada vertical (seta para cima, seta para baixo, teclas W e S)
        // Calcula a nova posição da raquete baseada na entrada e na velocidade
        // Limita a posição vertical da raquete para que ela não saia da tela
        // Atualiza a posição da raquete

        float moveInput = Input.GetAxis(movementAxisName);
        Vector3 newPosition = transform.position + moveInput * speed * Time.deltaTime * Vector3.up;
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);
        transform.position = newPosition;

        if ((SaveController.Instance.cpuAtivo) && (!isPlayer))
        {
            if (ball != null)
            {
                float targetY = Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f); // Limita a posição Y
                Vector2 targetPosition = new Vector2(transform.position.x, targetY);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed); // Move gradualmente para a posição Y da bola
            }
        }
    }
}
