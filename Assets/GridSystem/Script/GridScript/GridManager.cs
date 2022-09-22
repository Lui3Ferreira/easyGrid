using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{   //List of dummy GO
    public List<GameObject> MyGameItems = new List<GameObject>();
    public GameObject GameContainer;
    public GridViewModel GVM;
    private IGenerator gridGenerator;
    public Camera Camera;

    [SerializeField]
    private GameObject _infoPanel;

    [SerializeField]
    private GameObject _saveIcon;

    void Start()
    {
        InstantiateInfoPanel();

        //Inicicializes the new intance of the Model 
        GVM.Init();

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
            GameContainer);

        //Adds list of items to our grid
        gridGenerator.AddItemsToGrid(MyGameItems);
        //Fill default parameters to our View
        GVM.FillDefaultUiParameters((GridGenerator)gridGenerator, GameContainer);
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
        foreach (Transform child in GameContainer.transform)
        {
            if (GameContainer != null)
                Destroy(child.gameObject);
        }
        SetUpGridParam();
        gridGenerator.AddItemsToGrid(MyGameItems);
    }

    //Funtion that creates the grid based on the data of the Models
    private void SetUpGridParam()
    {
            var grid = (GridGenerator)gridGenerator;
            grid.ColumnLenght = GVM.Config.ColumnLenght;
            grid.RowLenght = GVM.Config.RowLenght;
            grid.XSpace = GVM.Config.XSpace;
            grid.YSpace = GVM.Config.YSpace;
            grid.XStart = GVM.Config.XStart;
            grid.YStart = GVM.Config.YStart;
            grid.ZStart = GVM.Config.ZStart;
            grid.Scale = GVM.Config.Scale;
            grid.Rotation = new Vector3(GVM.Config.RotX, GVM.Config.RotY, GVM.Config.RotZ);

            GameContainer.transform.localPosition = new Vector3(GVM.Config.EmptyPosX, GVM.Config.EmptyPosy, GVM.Config.EmptyPosZ);
            GameContainer.transform.localEulerAngles = new Vector3(GVM.Config.EmptyRotX, GVM.Config.EmptyRoty, GVM.Config.EmptyRotZ);
    }

    //Function that saves the parameters to the JSON file. Its called in the "Save Params." button
    public void SaveParametersToModel()
    {
        SaveLoadGridConfig.Instance.SaveSettings(GVM.Config);
        SaveFeedback();
    }

    //Function that will start the coroutine to show the save icon
    private void SaveFeedback()
    {
        StartCoroutine(HideShowGO.ShowAndHide(_saveIcon, 1.0f));
    }
}

