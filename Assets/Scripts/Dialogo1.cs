using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo1 : MonoBehaviour
{
    public string[] dialogueNpc;
    public int dialogueIndex;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameNpc;
    public Image imageNpc;
    public Sprite spriteNpc;
    public bool readyToSpeak = false;
    public bool startDialogue;
    private PlayerMove personagemScript;
    private Animator personagemAnimator;

    void Start()
    {
        dialoguePanel.SetActive(false);
        personagemScript = FindObjectOfType<PlayerMove>();
        if (personagemScript != null)
        {
            personagemAnimator = personagemScript.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("ScriptPersonagem n�o encontrado na cena!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && readyToSpeak)
        {
            if (!startDialogue)
            {
                // Desativa pulo e anima��o de corrida
                DesativarAnimacoes();
                StartDialogue();
            }
            else if (dialogueText.text == dialogueNpc[dialogueIndex])
            {
                NextDialogue();
            }
        }
    }

    void NextDialogue()
    {
        dialogueIndex++;
        if (dialogueIndex < dialogueNpc.Length)
        {
            StartCoroutine(showDialogue());
        }
        else
        {
            dialoguePanel.SetActive(false);
            startDialogue = false;
            dialogueIndex = 0;
            
            RestaurarAnimacoes();
        }
    }

    void StartDialogue()
    {
        nameNpc.text = "Boneco de Neve"; // Alterado para "Boneco de Neve"
        imageNpc.sprite = spriteNpc;
        startDialogue = true;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        StartCoroutine(showDialogue());
    }

    IEnumerator showDialogue()
    {
        dialogueText.text = "";
        foreach (char letter in dialogueNpc[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = false;
        }
    }

    // M�todo para desativar anima��es
    void DesativarAnimacoes()
    {
        if (personagemAnimator != null)
        {
            Debug.Log("Desativando anima��es");
            personagemAnimator.SetBool("Correndo", false);
            personagemAnimator.SetBool("Caindo", false);
            personagemAnimator.SetFloat("Velocidade", 0f);
            // Adicione qualquer outro par�metro que precise ser desativado
        }
    }

    // M�todo para restaurar anima��es
    void RestaurarAnimacoes()
    {
        if (personagemAnimator != null)
        {
            Debug.Log("Restaurando anima��es");
            // Ajuste os valores conforme necess�rio para restaurar o estado anterior
            personagemAnimator.SetBool("Correndo", true); // Se necess�rio, ajuste conforme a l�gica do seu jogo
        }
    }
}
