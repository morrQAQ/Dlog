using System;
using UnityEngine;

public static class DebuggingRegistry
{
    private const string FilterNativeLogsKey = "DebuggingRegistry.FilterNativeLogs";

#if !UNITY_EDITOR
    private static bool s_filterNativeLogs;
#endif

    /// <summary>
    /// When true, only logs from LogEx are shown; native Debug.Log from other code are suppressed.
    /// </summary>
    public static bool FilterNativeLogs
    {
        get =>
#if UNITY_EDITOR
            UnityEditor.EditorPrefs.GetBool(FilterNativeLogsKey, false);
#else
            s_filterNativeLogs;
#endif
        set
        {
#if UNITY_EDITOR
            UnityEditor.EditorPrefs.SetBool(FilterNativeLogsKey, value);
#else
            s_filterNativeLogs = value;
#endif
        }
    }

    public static bool IsEnabled(MonoBehaviour target)
    {
        if (target == null) return false;
#if UNITY_EDITOR
        return UnityEditor.EditorPrefs.GetBool(GetKey(target), false);
#else
        return false;
#endif
    }

#if UNITY_EDITOR
    public static void SetEnabled(MonoBehaviour target, bool enabled)
    {
        if (target == null) return;
        UnityEditor.EditorPrefs.SetBool(GetKey(target), enabled);
    }

    private static string GetKey(MonoBehaviour target) =>
        $"DebuggingRegistry:{target.GetInstanceID()}";
#endif
}


