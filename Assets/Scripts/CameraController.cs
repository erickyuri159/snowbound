using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // O jogador ou o objeto que a câmera deve seguir
    public Vector2 minPosition; // Posição mínima que a câmera pode atingir
    public Vector2 maxPosition; // Posição máxima que a câmera pode atingir

    void Update()
    {
        // Calcula a nova posição da câmera baseada na posição do alvo
        Vector3 newPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Limita a posição da câmera entre os valores mínimos e máximos
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

        // Atualiza a posição da câmera
        transform.position = newPosition;
    }
}
