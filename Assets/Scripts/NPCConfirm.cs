using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NPCConfirm : MonoBehaviour
{
    public GameObject confirmationPanel; // Painel de confirma��o
    public TextMeshProUGUI confirmationText; // Texto de confirma��o
    private bool playerInRange = false;

    void Start()
    {
        confirmationPanel.SetActive(false); // Esconde o painel no in�cio
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
        // Verifica se todas as pe�as est�o nos lugares corretos
        PuzzleManager puzzleManager = FindObjectOfType<PuzzleManager>();
        if (puzzleManager != null)
        {
            if (puzzleManager.AllSlotsOccupied())
            {
                // Mostra o painel de confirma��o com mensagem de sucesso
                confirmationText.text = "Parab�ns! Voc� completou o quebra-cabe�a.";
                confirmationPanel.SetActive(true);
                // Adicione um bot�o ou alguma l�gica aqui para finalizar o jogo
            }
            else
            {
                // Mostra o painel de confirma��o com mensagem de pe�as faltando
                confirmationText.text = "Ainda faltam pe�as para completar o quebra-cabe�a.";
                confirmationPanel.SetActive(true);
                StartCoroutine(HideConfirmationPanel());
            }
        }
    }

    IEnumerator HideConfirmationPanel()
    {
        yield return new WaitForSeconds(2f); // Esconde o painel ap�s 2 segundos
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
            confirmationPanel.SetActive(false); // Esconde o painel quando o jogador sai da �rea
        }
    }

    public void ConfirmCompletion()
    {
        Debug.Log("Jogo finalizado! Voc� completou o quebra-cabe�a.");
        SceneManager.LoadScene("VictoryScene"); // Carrega a cena de vit�ria
    }
}
