using UnityEngine;


public class PressurePlate : MonoBehaviour
{
    public Door door;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color activatedColor = Color.red;
    private int objectsOnPlate = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (objectsOnPlate == 0)
        {
            door.OpenDoor();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = activatedColor;
            }
        }
        objectsOnPlate++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        objectsOnPlate--;

        if (objectsOnPlate <= 0)
        {
            door.CloseDoor();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = originalColor;
            }
        }
    }
}


