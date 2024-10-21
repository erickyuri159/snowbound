using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // O jogador ou o objeto que a c�mera deve seguir
    public Vector2 minPosition; // Posi��o m�nima que a c�mera pode atingir
    public Vector2 maxPosition; // Posi��o m�xima que a c�mera pode atingir

    void Update()
    {
        // Calcula a nova posi��o da c�mera baseada na posi��o do alvo
        Vector3 newPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Limita a posi��o da c�mera entre os valores m�nimos e m�ximos
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

        // Atualiza a posi��o da c�mera
        transform.position = newPosition;
    }
}
