using UnityEngine;
using UnityEngine.UIElements;

public class ToolTipController
{
    public ToolTipController(VisualElement root)
    {
        VisualElement toolTipElem1 = root.Q("ToolTip_1");
        VisualElement toolTipElem2 = root.Q("ToolTip_2");
        VisualElement toolTipElem3 = root.Q("ToolTip_3");
        VisualElement toolTipElem4 = root.Q("ToolTip_4");


        ToolTip reuseableToolTip = new ToolTip();
        root.Add(reuseableToolTip);

        toolTipElem1.AddManipulator(new ToolTipManipulator(reuseableToolTip));
        toolTipElem2.AddManipulator(new ToolTipManipulator(reuseableToolTip));
        toolTipElem3.AddManipulator(new ToolTipManipulator(reuseableToolTip));
        toolTipElem4.AddManipulator(new ToolTipManipulator(reuseableToolTip));
    }
}
