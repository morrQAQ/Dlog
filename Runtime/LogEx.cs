using System;
using UnityEngine;

public static class LogEx
{
    public static void DLog(this MonoBehaviour self, string message)
    {
        if (!DebuggingRegistry.IsEnabled(self)) return;
        Debug.Log($"[{self.GetType().Name}] {message}", self);
    }

    public static void DLog(this MonoBehaviour self, string tag, string message)
    {
        if (!DebuggingRegistry.IsEnabled(self)) return;
        Debug.Log($"[{tag}] {message}", self);
    }

    public static void DLogWarning(this MonoBehaviour self, string message)
    {
        if (!DebuggingRegistry.IsEnabled(self)) return;
        Debug.LogWarning($"[{self.GetType().Name}] {message}", self);
    }

    public static void DLogError(this MonoBehaviour self, string message)
    {
        if (!DebuggingRegistry.IsEnabled(self)) return;
        Debug.LogError($"[{self.GetType().Name}] {message}", self);
    }

    public static void DLogException(this MonoBehaviour self, Exception exception)
    {
        if (!DebuggingRegistry.IsEnabled(self)) return;
        Debug.LogException(exception, self);
    }
}


