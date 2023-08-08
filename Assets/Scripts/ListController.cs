using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ListController
{
    VisualElement root;
    ListView list;

    List<ListItem> listItems;
    ListItem chosenItem;

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

        list.onSelectionChange += (elem) => OnSelectionChanged(elem);
    }
    private void OnSelectionChanged(IEnumerable<object> elem)
    {
        chosenItem = elem.First() as ListItem;
        UpdateDetails();
    }
    private void UpdateDetails()
    {
        VisualElement detailImg = root.Q<VisualElement>("DetailImg");
        Sprite iconImg = Resources.Load<Sprite>(chosenItem.itemIconPath);
        detailImg.style.backgroundImage = new StyleBackground(iconImg);

        Label detailLabel = root.Q<Label>("DetailName");
        detailLabel.text = chosenItem.itemName;

        Label detailScore = root.Q<Label>("DetailScore");
        detailScore.text = "Score " + chosenItem.score;

        VisualElement detailScoreImg = root.Q<VisualElement>("DetailScoreImg");
        Sprite scoreSprite = Resources.Load<Sprite>(chosenItem.itemIconPath2);
        detailScoreImg.style.backgroundImage = new StyleBackground(scoreSprite);

        Label rewardLabel = root.Q<Label>("DetailReward");
        rewardLabel.text = "Reward: " + chosenItem.reward;
    }
}
