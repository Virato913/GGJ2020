using UnityEngine;

public class Drag : MonoBehaviour
{

  private int IsOn = 0;
  Vector3 Size;
  Vector3 SizeTwo;
  int x = 0;
  Vector3 mousePos;// = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane));

  void Update()
  {
    if (IsOn == 0 || IsOn == 1)
    {
      if (Input.GetMouseButton(0))
      {
        //var collider2d = GetComponent<Collider2D>();

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane));

        //Debug.Log("y = " + mousePos.y);
        //Debug.Log((Vector2)mousePos);


        //if (collider2d.OverlapPoint(mousePos))
        //mousePos == transform.position && GetComponent<Collider2D>().OverlapPoint((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition))
        /*if (GetComponent<Collider2D>().OverlapPoint((Vector2)Camera.main.ScreenToWorldPoint(mousePos))) 
        {
            Debug.Log("AAA");
            IsOn = 1;
        }*/
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null)
        {
          Debug.Log("aaa");
          IsOn = 1;
          // raycast hit this gameobject
        }
      }
      if (IsOn == 1)
      {
        // transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);

      }
      if (Input.GetMouseButtonUp(0))
      {
        IsOn = 0;
      }
    }


  }

  private void OnTriggerStay2D(Collider2D other)
  {
    Size = TeSize();
    SizeTwo = TeSize(other);
    if (Size == SizeTwo && x == 0)
    {
      Debug.Log("hit detected");
      IsOn = 3;
      x += 1;
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
/* if (Input.GetMouseButton(0))
          {
              var collider2d = GetComponent<Collider2D>();
              var mousePos = Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
              transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

              Debug.Log((Vector2)mousePos);
              //mousePos.z = 0;
              // if (GetComponent<Collider2D>().OverlapPoint((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)))
              if (collider2d.OverlapPoint(mousePos)) 
              {
                  Debug.Log("AAA");
                  IsOn = 1;
              }
          }*/
