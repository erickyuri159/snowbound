using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public int pieceID;
    public Sprite pieceSprite;
    public bool isHeld = false;
    private Transform player;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = pieceSprite;
        spriteRenderer.sortingOrder = 2;
    }

    void Update()
    {
        if (isHeld && player != null)
        {
            transform.position = player.position;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            isHeld = !isHeld;
            if (isHeld)
            {
                player = other.transform;
                ShowSlot(true);
            }
            else
            {
                player = null;
                ShowSlot(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PuzzleSlot"))
        {
            PuzzleSlot slot = other.GetComponent<PuzzleSlot>();
            if (slot != null && slot.slotID == pieceID && isHeld)
            {
                // Automaticamente coloca a peça no slot
                slot.OccupySlot();
                transform.position = slot.transform.position;
                transform.parent = slot.transform;
                isHeld = false;
                ShowSlot(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.color = Color.white;
        }
    }

    private void ShowSlot(bool show)
    {
        PuzzleSlot[] slots = FindObjectsOfType<PuzzleSlot>();
        foreach (PuzzleSlot slot in slots)
        {
            if (slot.slotID == pieceID)
            {
                slot.ShowSlot(show);
            }
        }
    }
}
