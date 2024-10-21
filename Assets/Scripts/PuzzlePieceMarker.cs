using UnityEngine;

public class PuzzlePieceMarker : MonoBehaviour
{
    public GameObject markerPrefab; // Prefab do marcador
    private GameObject markerInstance;

    void Start()
    {
        // Cria uma instância do marcador
        markerInstance = Instantiate(markerPrefab, transform.position, Quaternion.identity);
        markerInstance.transform.SetParent(GameObject.Find("MiniMap Camera").transform, false);
    }

    void Update()
    {
        if (markerInstance != null)
        {
            markerInstance.transform.position = new Vector3(transform.position.x, markerInstance.transform.position.y, transform.position.z);
        }
    }

    void OnDestroy()
    {
        if (markerInstance != null)
        {
            Destroy(markerInstance); // Destroi o marcador quando a peça é coletada
        }
    }
}
