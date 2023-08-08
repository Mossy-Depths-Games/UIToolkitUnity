using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UIElements;

public class ToolTip: VisualElement
{
    UnityEngine.UIElements.Label label;
    public new class UxmlFactory : UxmlFactory<ToolTip> {  }

    private const string styleResource = "StyleSheets/StyleSheet_ToolTip";
    private const string ussElem = "tooltip";
    private const string ussLabel = "tooltip_text";

    public ToolTip()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
        AddToClassList(ussElem);
        AddToClassList(ussLabel);

        label = new UnityEngine.UIElements.Label();
        label.text = "Nice Tip";
        hierarchy.Add(label);

        style.position = Position.Absolute;
        pickingMode = PickingMode.Ignore;

        style.visibility = Visibility.Hidden;
    }
    public void Show(VisualElement target, Vector2 localMousePos)
    {
        label.text = target.tooltip;
        style.visibility = Visibility.Visible;
        style.left = target.worldBound.xMin + localMousePos.x;
        style.top = target.worldBound.yMin + localMousePos.y - 50;
    }
    public void Hide() 
    { 
        style.visibility = Visibility.Hidden;
    }
}
