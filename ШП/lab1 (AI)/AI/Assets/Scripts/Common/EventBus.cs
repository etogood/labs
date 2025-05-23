using System;
using System.Collections.Generic;

public static class EventBus
{
    private static readonly Dictionary<Type, Delegate> Map = new();

    public static void Subscribe<T>(Action<T> listener)
    {
        if (listener == null)
            return;
        Map.TryGetValue(typeof(T), out var dlg);
        Map[typeof(T)] = Delegate.Combine(dlg, listener);
    }

    public static void Unsubscribe<T>(Action<T> listener)
    {
        if (listener == null)
            return;
        if (!Map.TryGetValue(typeof(T), out var dlg))
            return;
        var newDlg = Delegate.Remove(dlg, listener);
        if (newDlg == null)
            Map.Remove(typeof(T));
        else
            Map[typeof(T)] = newDlg;
    }

    public static void Publish<T>(T evt)
    {
        if (Map.TryGetValue(typeof(T), out var dlg))
            (dlg as Action<T>)?.Invoke(evt);
    }
}
