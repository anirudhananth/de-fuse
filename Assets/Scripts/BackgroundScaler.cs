using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    Vector2 cameraSize;
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) return;

        Transform backgroundTransform = spriteRenderer.transform;
        float cameraHeight = Camera.main.orthographicSize * 2;
        cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = backgroundTransform.localScale;
        if (cameraSize.x >= cameraSize.y)
        { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        backgroundTransform.position = Vector2.zero; // Optional: Center the background
        backgroundTransform.localScale = new Vector3(scale.x, scale.y, 1);
    }
}