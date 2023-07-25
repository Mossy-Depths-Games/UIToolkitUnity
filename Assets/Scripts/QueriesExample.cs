using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class QueriesExample : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        UQueryBuilder<VisualElement> builder = new UQueryBuilder<VisualElement>(root);
        //Get all the results
        //List<VisualElement> result = builder.Build().ToList();
        //Get an element by name
        //VisualElement result = builder.Name("ElemContainer");
        //Get an element by label
        //List < Label > result = builder.OfType<Label>().ToList();
        //Get an element by name and store it in a list
        //List<VisualElement> result1 = builder.Name("Elem1").ToList();

       /*
       builder.Name("Elem1").Build();
       builder.Name("Elem2").Build();
       builder.Name("Elem3").Build();
       List<VisualElement> result = builder.ToList();
       */

       //Where works fine
       //List<VisualElement> result = builder.Where(a => a.name == "Elem1" || a.name == "Elem2" || a.name == "Elem3").ToList();

        VisualElement elem1Q = root.Q("Elem1");
        VisualElement elem1Query = root.Query("Elem1").First();
        //Get the first element with the class
        //VisualElement result = root.Q(className: "basicSquareElem");

        //Get all elements with this name
        //List<VisualElement> result = root.Query(name: "Elem2").ToList();

        //Get everything below and including root
        List<VisualElement> result = root.Query().ToList();
        //Get everything below and including Elem1
        result = elem1Query.Query().ToList();

        //Change all the elements background color with a ForEach
        root.Query(className: "basicSquareElem").ForEach(elem => elem.style.backgroundColor = Color.black);
        result = root.Query(className: "basicSquareElem").Where(elem => elem.GetType() == typeof(Label)).ToList();
        List<Label> result1 = root.Query<Label>().Where(elem => elem.text == "3").ToList();
        result = root.Query().Class("basicSquareElem").ToList();

        markElem(result1);
    }
    private void markElem(VisualElement element)
    {
        element.AddToClassList("marker");
    }
    private void markElem(List<VisualElement> elements)
    {
        elements.ForEach(elem => elem.AddToClassList("marker"));
    }
    private void markElem(List<Label> elements)
    {
        elements.ForEach(elem => elem.AddToClassList("marker"));
    }
}
