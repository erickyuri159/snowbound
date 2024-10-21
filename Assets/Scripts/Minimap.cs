using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player; // Refer�ncia ao jogador

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y; // Mant�m a altura da c�mera do minimapa
        transform.position = newPosition;
    }
}
