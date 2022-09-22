using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{   //List of dummy GO
    [SerializeField]
    private List<GameObject> _myGameItems = new List<GameObject>();
    [SerializeField]
    private GridViewModel _gvm;
    private IGenerator gridGenerator;
    [SerializeField]
    private GameObject _infoPanel, _saveIcon, _gameContainer;

    void Start()
    {
        InstantiateInfoPanel();

        //Inicicializes the new intance of the Model 
        _gvm.Init();

        //Creates a default grid
        gridGenerator = new GridGenerator(
            4, //column Lenght
            2, //RowLenght 
            2.0f, //x_space
            2.0f, //y_space 
            0, //x_start 
            0, //y_start 
            0, //z_start    
            1, //scale
            new Vector3(0f, 0f, 0f), //empty_GO_rotation)
            _gameContainer);

        //Adds list of items to our grid
        gridGenerator.AddItemsToGrid(_myGameItems);
        //Fill default parameters to our View
        _gvm.FillDefaultUiParameters((GridGenerator)gridGenerator, _gameContainer);
    }

    //Function that will display the InfoPanel prefab
    private void InstantiateInfoPanel()
    {
        GameObject info = Instantiate(_infoPanel, new Vector3(0, 0, 0), Quaternion.identity);
        info.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

    //Generates grids based on our Model. Its called in the "Create Grid Button"
    public void GenerateNewGrid()
    {
        foreach (Transform child in _gameContainer.transform)
        {
            if (_gameContainer != null)
                Destroy(child.gameObject);
        }
        SetUpGridParam();
        gridGenerator.AddItemsToGrid(_myGameItems);
    }

    //Funtion that creates the grid based on the data of the Models
    private void SetUpGridParam()
    {
            var grid = (GridGenerator)gridGenerator;
            grid.ColumnLenght = _gvm.Config.ColumnLenght;
            grid.RowLenght = _gvm.Config.RowLenght;
            grid.XSpace = _gvm.Config.XSpace;
            grid.YSpace = _gvm.Config.YSpace;
            grid.XStart = _gvm.Config.XStart;
            grid.YStart = _gvm.Config.YStart;
            grid.ZStart = _gvm.Config.ZStart;
            grid.Scale = _gvm.Config.Scale;
            grid.Rotation = new Vector3(_gvm.Config.RotX, _gvm.Config.RotY, _gvm.Config.RotZ);

            _gameContainer.transform.localPosition = new Vector3(_gvm.Config.EmptyPosX, _gvm.Config.EmptyPosy, _gvm.Config.EmptyPosZ);
            _gameContainer.transform.localEulerAngles = new Vector3(_gvm.Config.EmptyRotX, _gvm.Config.EmptyRoty, _gvm.Config.EmptyRotZ);
    }

    //Function that saves the parameters to the JSON file. Its called in the "Save Params." button
    public void SaveParametersToModel()
    {
        SaveLoadGridConfig.Instance.SaveSettings(_gvm.Config);
        SaveFeedback();
    }

    //Function that will start the coroutine to show the save icon
    private void SaveFeedback()
    {
        StartCoroutine(HideShowGO.ShowAndHide(_saveIcon, 1.0f));
    }
}

