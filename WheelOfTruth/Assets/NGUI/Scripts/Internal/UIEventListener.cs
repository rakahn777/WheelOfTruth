//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------
using UnityEngine;

/// <summary>
/// Event Hook class lets you easily add remote event listener functions to an object.
/// Example usage: UIEventListener.Get(gameObject).onClick += MyClickFunction;
/// </summary>
[AddComponentMenu("NGUI/Internal/Event Listener")]
public class UIEventListener : MonoBehaviour
{
    public delegate void VoidDelegate(GameObject go);

    public delegate void BoolDelegate(GameObject go, bool state);

    public delegate void FloatDelegate(GameObject go, float delta);

    public delegate void VectorDelegate(GameObject go, Vector2 delta);

    public delegate void ObjectDelegate(GameObject go, GameObject obj);

    public delegate void KeyCodeDelegate(GameObject go, KeyCode key);

    public object parameter;

    public VoidDelegate onSubmit;
    public VoidDelegate onClick;
    public VoidDelegate onDoubleClick;
    public BoolDelegate onHover;
    public BoolDelegate onPress;
    public BoolDelegate onSelect;
    public FloatDelegate onScroll;
    public VoidDelegate onDragStart;
    public VectorDelegate onDrag;
    public VoidDelegate onDragOver;
    public VoidDelegate onDragOut;
    public VoidDelegate onDragEnd;
    public ObjectDelegate onDrop;
    public KeyCodeDelegate onKey;
    public BoolDelegate onTooltip;
    public bool Enable = true;

    private void OnSubmit()
    {
        if (onSubmit != null && Enable) onSubmit(gameObject);
    }

    private void OnClick()
    {
        if (onClick != null)
        {
            if (Enable)
                onClick(gameObject);
        }
    }

    private void OnDoubleClick()
    {
        if (onDoubleClick != null && Enable) onDoubleClick(gameObject);
    }

    private void OnHover(bool isOver)
    {
        if (onHover != null && Enable) onHover(gameObject, isOver);
    }

    private void OnPress(bool isPressed)
    {
        if (onPress != null && Enable) onPress(gameObject, isPressed);
    }

    private void OnSelect(bool selected)
    {
        if (onSelect != null && Enable) onSelect(gameObject, selected);
    }

    private void OnScroll(float delta)
    {
        if (onScroll != null && Enable) onScroll(gameObject, delta);
    }

    private void OnDragStart()
    {
        if (onDragStart != null && Enable) onDragStart(gameObject);
    }

    private void OnDrag(Vector2 delta)
    {
        if (onDrag != null && Enable) onDrag(gameObject, delta);
    }

    private void OnDragOver()
    {
        if (onDragOver != null && Enable) onDragOver(gameObject);
    }

    private void OnDragOut()
    {
        if (onDragOut != null && Enable) onDragOut(gameObject);
    }

    private void OnDragEnd()
    {
        if (onDragEnd != null && Enable) onDragEnd(gameObject);
    }

    private void OnDrop(GameObject go)
    {
        if (onDrop != null && Enable) onDrop(gameObject, go);
    }

    private void OnKey(KeyCode key)
    {
        if (onKey != null && Enable) onKey(gameObject, key);
    }

    private void OnTooltip(bool show)
    {
        if (onTooltip != null && Enable) onTooltip(gameObject, show);
    }

    /// <summary>
    /// Get or add an event listener to the specified game object.
    /// </summary>
    public static UIEventListener Get(GameObject go)
    {
        UIEventListener listener = go.GetComponent<UIEventListener>();
        if (listener == null) listener = go.AddComponent<UIEventListener>();
        UIButtonColor color = go.GetComponent<UIButtonColor>();
        if (color == null) go.AddComponent<UIButtonColor>();
        return listener;
    }
}