using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class StarControl : VisualElement
{
    public new class UxmlFactory : UxmlFactory<StarControl, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits 
    {
        UxmlIntAttributeDescription starAttrbute = new UxmlIntAttributeDescription()
        {
            name = "stars"
        };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);

            (ve as StarControl).Stars = starAttrbute.GetValueFromBag(bag, cc);
        }
    }

    private const string styleResource = "StyleSheets/StyleSheet_StarControl";
    private const string ussContainer = "container";
    private const string ussOuterStar = "outerStar";
    private const string ussInnerStar = "innerStar";

    private List<VisualElement> outerStars = new List<VisualElement>();
    private List<VisualElement> innerStars = new List<VisualElement>();

    private int stars;
    public int Stars
    {
        get { return stars; } 
        set { stars = value; SetStars();  }
    }

    public StarControl() 
    {
        StyleSheet styleSheet = Resources.Load<StyleSheet>(styleResource);
        styleSheets.Add(styleSheet);

        VisualElement container = new VisualElement();
        //container.name = ussContainer;
        hierarchy.Add(container);
        container.AddToClassList(ussContainer);

        for (int i = 0; i < 7; ++i)
        {
            VisualElement outerStarTemp = new VisualElement();
            outerStarTemp.name = ussOuterStar;
            outerStarTemp.AddToClassList(ussOuterStar);
            container.Add(outerStarTemp);
            
            outerStars.Add(outerStarTemp);

            VisualElement innerStarTemp = new VisualElement();
            innerStarTemp.name = ussInnerStar;
            outerStarTemp.Add(innerStarTemp);
            innerStarTemp.AddToClassList(ussInnerStar);

            innerStars.Add(innerStarTemp);
        }
    }
    void SetStars()
    {
        HideAllStars();
        innerStars.Take(stars).ToList().ForEach(innerStar => { innerStar.style.visibility = Visibility.Visible; });
    }
    void HideAllStars()
    {
        innerStars.ForEach(innerStar => { innerStar.style.visibility = Visibility.Hidden; });
    }
}
