using UnityEngine;

public class CCameraFollower : MonoBehaviour
{
  [Header("Settings")]
  public float smoothSpeed = 10.0f;
  public Vector3 offset;
  public Transform lookAtObject;

  private void Start()
  {
    lookAtObject = GameObject.FindGameObjectWithTag("Player").transform;
  }

  private void FixedUpdate()
  {
    Vector3 desiredPosition = lookAtObject.position + offset;
    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    transform.position = smoothedPosition;
  }
}
