#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CPlayer))]
public class CPlayerEditor : Editor
{
  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    CPlayer myTarget = (CPlayer)target;

    myTarget.Direction = (myTarget.Direction.magnitude != 0) ?
      myTarget.Direction.normalized :
      new Vector3(0.0f, 0.0f, -1.0f);
    myTarget.InteractRange = Mathf.Clamp(Mathf.Abs(myTarget.InteractRange), 1.0f, 5.0f);
    myTarget.UpdateRotation();
  }
}
#endif
