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

    myTarget.Direction = EditorGUILayout.Vector2Field("Start Direction",
      myTarget.Direction.normalized);
    myTarget.InteractRange = EditorGUILayout.FloatField("Interact Range",
      Mathf.Clamp(Mathf.Abs(myTarget.InteractRange), 1.0f, 5.0f));
  }
}
#endif
