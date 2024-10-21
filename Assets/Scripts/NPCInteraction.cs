using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject promptImage; // A imagem que mostra a letra "E"
    public Transform player; // O transform do jogador
    public float proximityDistance = 2f; // Dist�ncia em que o prompt aparece

    void Update()
    {
        // Calcula a dist�ncia entre o jogador e o NPC
        float distance = Vector3.Distance(player.position, transform.position);

        // Mostra a imagem se estiver pr�ximo o suficiente
        if (distance <= proximityDistance)
        {
            promptImage.SetActive(true);
        }
        else
        {
            promptImage.SetActive(false);
        }
    }
}
