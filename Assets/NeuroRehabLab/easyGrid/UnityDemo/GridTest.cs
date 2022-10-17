using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GenerateGrids;
using GeneratorInterface;

public class GridTest : MonoBehaviour
{
    private IGenerator gridGenerator;
    //Reference of your empty game object
    public GameObject GameContainer;
    //List of game objects that you want to display in your scene
    public List<GameObject> MyGameItems = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //Create a grid object and add an empty object as a parameter
        gridGenerator = new GridGenerator(GameContainer);

        //Setup grid parameters by adding the array index position in the JSON FILE
        gridGenerator.SetUpJsonGrid(0);

        //Add your list items to the new grid!
        gridGenerator.AddItemsToGrid(MyGameItems);
    }
}
