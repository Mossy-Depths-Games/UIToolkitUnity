using UnityEngine;
using UnityEngine.UIElements;

public class CardViewModel
{
    CharacterModel characterModel;
    VisualElement cardRoot;

    Label nameLabel;
    Label descriptionLabel;
    VisualElement avatarImage;

    public VisualElement CardRoot { get => cardRoot; set => cardRoot = value; }

    public CardViewModel(VisualElement cardRoot, CharacterModel characterModel)
    {
        this.CardRoot = cardRoot;
        this.characterModel = characterModel;

        cardRoot = cardRoot.Q(className: "card");

        cardRoot.userData = characterModel;
        nameLabel = cardRoot.Q<Label>("NameLabel");
        descriptionLabel = cardRoot.Q<Label>("DescriptionLabel");
        avatarImage = cardRoot.Q("Avatar");

        //make everything below the card not selectable
        cardRoot.Query(className: "card").Descendents<VisualElement>().ForEach(elem => elem.pickingMode = PickingMode.Ignore);

        SetImge();
        UpdateUI();

        characterModel.onChanged += UpdateUI;
    }
    void SetImge()
    {
        Sprite avatarSprite = Resources.Load<Sprite>(characterModel.ImagePath);
        avatarImage.style.backgroundImage = new StyleBackground(avatarSprite);
    }
    private void UpdateUI()
    {
        nameLabel.text = characterModel.Name;
        descriptionLabel.text = characterModel.Description;
    }
}
