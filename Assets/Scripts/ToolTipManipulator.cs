using UnityEngine.UIElements;

public class ToolTipManipulator : PointerManipulator
{
    private ToolTip toolTip;
    public ToolTipManipulator(ToolTip toolTip)
    {
        this.toolTip = toolTip;
    }
    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<PointerEnterEvent>(OnPointerEnter);
        target.RegisterCallback<PointerLeaveEvent>(OnPointerExit);
    }
    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<PointerEnterEvent>(OnPointerEnter);
        target.UnregisterCallback<PointerLeaveEvent>(OnPointerExit);
    }
    private void OnPointerEnter(PointerEnterEvent e)
    {
        toolTip.Show(target, e.localPosition);
    }
    private void OnPointerExit(PointerLeaveEvent e)
    {
        toolTip.Hide();
    }
}
