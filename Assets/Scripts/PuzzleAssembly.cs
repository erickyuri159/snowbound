using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAssembly : MonoBehaviour
{
    public Transform[] puzzleSlots;
    private int piecesCollected = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PuzzlePiece"))
        {
            // Verifica se o jogador está segurando a peça
            PuzzlePiece piece = other.GetComponent<PuzzlePiece>();
            if (piece != null && piece.isHeld)
            {
                // Encontra o slot correto baseado em um identificador
                foreach (Transform slot in puzzleSlots)
                {
                    PuzzleSlot puzzleSlot = slot.GetComponent<PuzzleSlot>();
                    if (puzzleSlot != null && puzzleSlot.slotID == piece.pieceID)
                    {
                        // Coloca a peça no slot correto
                        other.transform.position = slot.position;
                        other.transform.parent = slot;
                        piece.isHeld = false;
                        piecesCollected++;
                        break;
                    }
                }
            }
        }
    }
}
