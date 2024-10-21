using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player; // Referência ao jogador

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y; // Mantém a altura da câmera do minimapa
        transform.position = newPosition;
    }
}
