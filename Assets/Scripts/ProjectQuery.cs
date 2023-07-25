using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectQuery : MonoBehaviour
{
    VisualElement root;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        InitializeBadges();
    }

    private void InitializeBadges()
    {
        string[] romanNumerals = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
        List<VisualElement> badgeLabels = root.Query("PanelBadges").Descendents<VisualElement>().Name("LabelLevel").ToList();
        int counter = 0;
        foreach (Label label in badgeLabels)
        {
            label.text = romanNumerals[counter];
            counter++;
        }
    }
}
