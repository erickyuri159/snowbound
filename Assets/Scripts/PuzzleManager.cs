using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzlePieces; // Prefabs das pe�as do quebra-cabe�a
    public Vector2[] specificPoints; // Pontos espec�ficos onde as pe�as podem aparecer
    private List<Vector2> availablePoints;
    public GameObject completeImage; // Refer�ncia � imagem completa
    void Start()
    {
        puzzleSlots = FindObjectsOfType<PuzzleSlot>();
        completeImage.SetActive(false);// Esconde a imagem completa no in�cio
        SpawnPuzzlePieces();
    }

    void SpawnPuzzlePieces()
    {
        // Copia os pontos espec�ficos para a lista de pontos dispon�veis
        availablePoints = new List<Vector2>(specificPoints);

        foreach (GameObject piece in puzzlePieces)
        {
            if (availablePoints.Count == 0)
            {
                Debug.LogWarning("N�o h� pontos suficientes para todas as pe�as do quebra-cabe�a.");
                return;
            }

            // Pega um ponto aleat�rio e remove da lista de pontos dispon�veis
            int randomIndex = Random.Range(0, availablePoints.Count);
            Vector2 randomPosition = availablePoints[randomIndex];
            availablePoints.RemoveAt(randomIndex);

            // Instancia a pe�a no ponto aleat�rio
            Instantiate(piece, randomPosition, Quaternion.identity);
        }
    }

    public PuzzleSlot[] puzzleSlots;

    public void CheckCompletion()
    {
        foreach (PuzzleSlot slot in puzzleSlots)
        {
            if (!slot.isOccupied)
                return; // Se algum slot n�o est� ocupado, ainda n�o completou
        }
        // Todos os slots est�o ocupados
        WinGame();
    }

    void WinGame()
    {
        Debug.Log("Voc� completou o quebra-cabe�a e ganhou o jogo!");
        // Voc� pode adicionar outras a��es aqui, como carregar uma cena de vit�ria
        completeImage.SetActive(true); // Exibe a imagem completa
        // Adicione outras a��es aqui, como uma tela de vit�ria ou efeito visual
    }
    public bool AllSlotsOccupied()
    {
        foreach (PuzzleSlot slot in puzzleSlots)
        {
            if (!slot.isOccupied)
            {
                return false;
            }
        }
        return true;
    }
}
