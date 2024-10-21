using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{

    public int slotID;
    public Color slotColor = new Color(1f, 1f, 1f, 0.5f);
    public Color gizmoColor = Color.green;
    public Sprite slotSprite; // Adicione um campo para o sprite
    
    public bool isOccupied = false;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Adicione um SpriteRenderer ao GameObject e configure o sprite
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = slotSprite;
        spriteRenderer.color = slotColor;
        
        spriteRenderer.sortingOrder = 1; // Certifique-se que o sprite fica visível
        spriteRenderer.enabled = false; // Inicia com o sprite desativado

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PuzzlePiece"))
        {
            PuzzlePiece piece = other.GetComponent<PuzzlePiece>();
            if (piece != null && piece.pieceID == slotID && piece.isHeld)
            {
                // Automaticamente coloca a peça no slot
                piece.transform.position = transform.position;
                piece.transform.parent = transform;
                piece.isHeld = false;
                isOccupied = true;
                FindObjectOfType<PuzzleManager>().CheckCompletion();
            }
        }
    }
    public void ShowSlot(bool show)
    {
        spriteRenderer.enabled = show;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, 0.5f); // Desenha uma esfera na posição do slot
    }
    public void OccupySlot()
    {
        isOccupied = true;
        ShowSlot(false); // Desativa o visual do slot quando ocupado
        FindObjectOfType<PuzzleManager>().CheckCompletion(); // Verifica a conclusão do jogo
    }
}
