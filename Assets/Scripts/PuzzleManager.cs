using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzlePieces; // Prefabs das peças do quebra-cabeça
    public Vector2[] specificPoints; // Pontos específicos onde as peças podem aparecer
    private List<Vector2> availablePoints;
    public GameObject completeImage; // Referência à imagem completa
    void Start()
    {
        puzzleSlots = FindObjectsOfType<PuzzleSlot>();
        completeImage.SetActive(false);// Esconde a imagem completa no início
        SpawnPuzzlePieces();
    }

    void SpawnPuzzlePieces()
    {
        // Copia os pontos específicos para a lista de pontos disponíveis
        availablePoints = new List<Vector2>(specificPoints);

        foreach (GameObject piece in puzzlePieces)
        {
            if (availablePoints.Count == 0)
            {
                Debug.LogWarning("Não há pontos suficientes para todas as peças do quebra-cabeça.");
                return;
            }

            // Pega um ponto aleatório e remove da lista de pontos disponíveis
            int randomIndex = Random.Range(0, availablePoints.Count);
            Vector2 randomPosition = availablePoints[randomIndex];
            availablePoints.RemoveAt(randomIndex);

            // Instancia a peça no ponto aleatório
            Instantiate(piece, randomPosition, Quaternion.identity);
        }
    }

    public PuzzleSlot[] puzzleSlots;

    public void CheckCompletion()
    {
        foreach (PuzzleSlot slot in puzzleSlots)
        {
            if (!slot.isOccupied)
                return; // Se algum slot não está ocupado, ainda não completou
        }
        // Todos os slots estão ocupados
        WinGame();
    }

    void WinGame()
    {
        Debug.Log("Você completou o quebra-cabeça e ganhou o jogo!");
        // Você pode adicionar outras ações aqui, como carregar uma cena de vitória
        completeImage.SetActive(true); // Exibe a imagem completa
        // Adicione outras ações aqui, como uma tela de vitória ou efeito visual
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
