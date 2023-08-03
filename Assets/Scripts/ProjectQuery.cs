using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectQuery : MonoBehaviour
{
    [SerializeField]
    private List<Faction> factions = new List<Faction>();
    [SerializeField]
    private List<ListItem> listItems = new List<ListItem>();

    VisualElement root;
    DropdownController dropdownController;
    ListController listController;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        InitializeBadges();
        dropdownController = new DropdownController(root, factions);
        listController = new ListController(root, listItems);
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
