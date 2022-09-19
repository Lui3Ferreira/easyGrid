using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    private IGenerator gridGenerator;
    public GameObject GameContainer;
    public List<GameObject> MyGameItems = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //Create a grid object and add an epty object as parameter
        gridGenerator = new GridGenerator(GameContainer);

        //Setup grid parameters by adding the array index position in the JSON FILE
        gridGenerator.SetUpJsonGrid(1);

        //Add your list items to new grid!
        gridGenerator.AddItemsToGrid(MyGameItems);
    }
}
