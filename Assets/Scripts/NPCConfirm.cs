using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NPCConfirm : MonoBehaviour
{
    public GameObject confirmationPanel; // Painel de confirmação
    public TextMeshProUGUI confirmationText; // Texto de confirmação
    private bool playerInRange = false;

    void Start()
    {
        confirmationPanel.SetActive(false); // Esconde o painel no início
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            CheckPuzzleCompletion();
        }
    }

    void CheckPuzzleCompletion()
    {
        // Verifica se todas as peças estão nos lugares corretos
        PuzzleManager puzzleManager = FindObjectOfType<PuzzleManager>();
        if (puzzleManager != null)
        {
            if (puzzleManager.AllSlotsOccupied())
            {
                // Mostra o painel de confirmação com mensagem de sucesso
                confirmationText.text = "Parabéns! Você completou o quebra-cabeça.";
                confirmationPanel.SetActive(true);
                // Adicione um botão ou alguma lógica aqui para finalizar o jogo
            }
            else
            {
                // Mostra o painel de confirmação com mensagem de peças faltando
                confirmationText.text = "Ainda faltam peças para completar o quebra-cabeça.";
                confirmationPanel.SetActive(true);
                StartCoroutine(HideConfirmationPanel());
            }
        }
    }

    IEnumerator HideConfirmationPanel()
    {
        yield return new WaitForSeconds(2f); // Esconde o painel após 2 segundos
        confirmationPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            confirmationPanel.SetActive(false); // Esconde o painel quando o jogador sai da área
        }
    }

    public void ConfirmCompletion()
    {
        Debug.Log("Jogo finalizado! Você completou o quebra-cabeça.");
        SceneManager.LoadScene("VictoryScene"); // Carrega a cena de vitória
    }
}
