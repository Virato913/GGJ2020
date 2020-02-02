using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collition : MonoBehaviour
{
    Vector3 Size;
    Vector3 SizeTwo;

    private void OnTriggerStay2D(Collider2D other)
    {
        Size = TeSize();
        SizeTwo = TeSize(other);
        if (Size == SizeTwo)
        {
          other.transform.position = Vector2.Lerp(transform.position, new Vector2(20, 20), 4 * Time.fixedDeltaTime);

        }

    }
    private Vector3 TeSize()
    {
        Vector2 sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector3 world_size = local_sprite_size;
        world_size.x *= transform.lossyScale.x;
        world_size.y *= transform.lossyScale.y;

        Vector3 screen_size = 0.5f * world_size / Camera.main.orthographicSize;
        screen_size.y *= Camera.main.aspect;

        return screen_size;
    }

    private Vector3 TeSize(Collider2D other)
    {
        Vector2 sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector3 world_size = local_sprite_size;
        world_size.x *= other.transform.lossyScale.x;
        world_size.y *= other.transform.lossyScale.y;

        Vector3 screen_size = 0.5f * world_size / Camera.main.orthographicSize;
        screen_size.y *= Camera.main.aspect;

        return screen_size;
    }
}
