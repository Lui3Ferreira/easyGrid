using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GenerateGrids;
using GeneratorInterface;

namespace TestScript
{
    public class GridTest : MonoBehaviour
    {
        private IGenerator gridGenerator;
        //Reference of your empty game object
        [SerializeField]
        private GameObject _gameContainer;
        //List of game objects that you want to display in your scene
        [SerializeField]
        private List<GameObject> _myGameItems = new List<GameObject>();

        // Start is called before the first frame update
        public void Start()
        {
        //Create a grid object and add an empty object as a parameter
            gridGenerator = new GridGenerator(_gameContainer);

            //Setup grid parameters by adding the array index position in the JSON FILE
            gridGenerator.SetUpJsonGrid(0);

            //Add your list items to the new grid!
            gridGenerator.AddItemsToGrid(_myGameItems);
        }
    }
}


