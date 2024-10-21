using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DesistirComponent : MonoBehaviour
{
    public float slowDownDuration = 2f; // Dura��o da lentid�o
    public float slowDownSpeed = 2f; // Velocidade reduzida
    public string[] desistirFrases; // Array de frases de desist�ncia
    public TextMeshProUGUI fraseText; // Campo de texto para exibir a frase

    private PlayerMove playerMove;
    private float normalSpeed;
    private bool isSlowedDown = false;

    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        normalSpeed = playerMove.speed;
        fraseText.gameObject.SetActive(false); // Inicialmente desativa o texto
    }

    void Update()
    {
        // Dispara o efeito de lentid�o e frase aleatoriamente
        if (!isSlowedDown && Random.Range(0, 1000) < 5) // Ajuste a chance conforme necess�rio
        {
            StartCoroutine(TriggerDesistir());
        }
    }

    IEnumerator TriggerDesistir()
    {
        isSlowedDown = true;
        playerMove.speed = slowDownSpeed;

        // Escolhe uma frase aleat�ria e exibe
        fraseText.text = desistirFrases[Random.Range(0, desistirFrases.Length)];
        fraseText.gameObject.SetActive(true);

        // Espera o tempo de lentid�o
        yield return new WaitForSeconds(slowDownDuration);

        // Volta ao normal
        playerMove.speed = normalSpeed;
        fraseText.gameObject.SetActive(false);
        isSlowedDown = false;
    }
}
