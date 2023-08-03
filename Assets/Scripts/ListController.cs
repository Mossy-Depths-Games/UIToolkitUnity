using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ListController
{
    VisualElement root;
    ListView list;

    List<ListItem> listItems;

    public ListController(VisualElement root, List<ListItem> listItems)
    {
        this.listItems = listItems;
        this.root = root;

        CreateList();
    }

    private void CreateList()
    {
        list = root.Q<ListView>("List");
        VisualTreeAsset listItemAsset = Resources.Load<VisualTreeAsset>("ListItem");

        list.makeItem = () => listItemAsset.Instantiate();
        list.bindItem = (ve, i) =>
        {
            VisualElement factionIcon = ve.Q<VisualElement>("FactionIcon");
            Label listItemName = ve.Q<Label>("ListItemName");
            Label score = ve.Q<Label>("Score");
            VisualElement otherIcon = ve.Q<VisualElement>("OtherIcon");
            Label reward = ve.Q<Label>("Reward");

            ListItem currentItem = listItems[i];

            Sprite iconImg = Resources.Load<Sprite>(currentItem.itemIconPath);
            factionIcon.style.backgroundImage = new StyleBackground(iconImg);

            listItemName.text = currentItem.itemName;
            score.text = currentItem.score;

            Sprite iconImg2 = Resources.Load<Sprite>(currentItem.itemIconPath2);
            otherIcon.style.backgroundImage = new StyleBackground(iconImg2);

            reward.text = "Reward " + currentItem.reward;
        };

        list.itemsSource = listItems;
        list.fixedItemHeight = 35;
    }
}
