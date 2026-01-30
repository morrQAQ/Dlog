using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(MonoBehaviour), true)]
public class MonoBehaviourDebuggingInspector : Editor
{
    private bool _initialized;
    private bool _debugging;

    public override void OnInspectorGUI()
    {
        if (targets != null && targets.Length > 0 && targets[0] is MonoBehaviour mb)
        {
            if (!_initialized)
            {
                _debugging = DebuggingRegistry.IsEnabled(mb);
                _initialized = true;
            }

            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUILayout.LabelField("Debugging", EditorStyles.boldLabel);

                EditorGUI.BeginChangeCheck();
                var next = EditorGUILayout.Toggle("Debugging", _debugging);
                if (EditorGUI.EndChangeCheck())
                {
                    _debugging = next;
                    foreach (var t in targets)
                    {
                        if (t is MonoBehaviour x)
                            DebuggingRegistry.SetEnabled(x, _debugging);
                    }
                }

                EditorGUI.BeginChangeCheck();
                var filterNative = EditorGUILayout.Toggle("Filter native Debug.Log", DebuggingRegistry.FilterNativeLogs);
                if (EditorGUI.EndChangeCheck())
                    DebuggingRegistry.FilterNativeLogs = filterNative;
            }
            EditorGUILayout.Space(8);
        }

        DrawDefaultInspector();
    }
}


