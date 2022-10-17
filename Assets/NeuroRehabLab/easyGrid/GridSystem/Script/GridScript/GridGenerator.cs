using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using GeneratorInterface;

namespace GenerateGrids
{
    public class GridGenerator : IGenerator
    {
        private int _columnLenght;
        private int _rowLenght;
        private float _xSpace;
        private float _ySpace;
        private float _xStart;
        private float _yStart;
        private float _zStart;
        private float _scale;
        private Vector3 _rotation;
        private GameObject _prefab;
        private List<GameObject> _instanciateGameObjects;
        private GameObject _emptyGameObject;

        //Default constructor
        public GridGenerator(GameObject emptyGameObject = null)
        {
            this._emptyGameObject = emptyGameObject;
            _instanciateGameObjects = new List<GameObject>();
        }

        /// <summary>
        /// Call this constructor if you want to create a Grid manually 
        /// </summary>
        /// <param name="columnLenght"></param>
        /// <param name="rowLenght"></param>
        /// <param name="xSpace"></param>
        /// <param name="ySpace"></param>
        /// <param name="xStart"></param>
        /// <param name="yStart"></param>
        /// <param name="zStart"></param>
        /// <param name="scale"></param>
        /// <param name="rotation"></param>
        /// <param name="emptyGameObject"></param>
        public GridGenerator(int columnLenght, int rowLenght, float xSpace, float ySpace, float xStart, float yStart, float zStart, float scale, Vector3 rotation, GameObject emptyGameObject = null)
        {
            this._columnLenght = columnLenght;
            this._rowLenght = rowLenght;
            this._xSpace = xSpace;
            this._ySpace = ySpace;
            this._xStart = xStart;
            this._yStart = yStart;
            this._zStart = zStart;
            this._scale = scale;
            this._rotation = rotation;
            this._emptyGameObject = emptyGameObject;

            _instanciateGameObjects = new List<GameObject>();
        }

        //Function that adds items to grid
        public void AddItemsToGrid(List<GameObject> gOs)
        {
            var index = 0;

            for (int i = 0; i < gOs.Count; i++)
            {
                _instanciateGameObjects.Add(gOs[i]);

                if (i < ColumnLenght * RowLenght)
                {
                    InstantiatePrefabs(_instanciateGameObjects, i, Scale, Rotation, EmptyGameObject);
                    index = i;
                }
            }
            _instanciateGameObjects.RemoveRange(0, index + 1);
        }

        private void InstantiatePrefabs(List<GameObject> GOs, int index, float scale, Vector3 rotation, GameObject AddGoToEmptyGo = null)
        {
            GameObject prefab = Object.Instantiate(GOs[index], new Vector3(XStart + (XSpace * (index % ColumnLenght)), YStart + (-YSpace * (index / ColumnLenght)), _zStart), Quaternion.identity);

            prefab.transform.localScale = new Vector3(scale, scale, scale);
            prefab.transform.Rotate(rotation);

            if (AddGoToEmptyGo != null)
                prefab.transform.SetParent(AddGoToEmptyGo.transform, false);
        }

        /// <summary>
        /// Function that setup Grid from JSON file. It receives an int as parameter that is the index of the JSON file 
        /// </summary>
        /// <param name="gridJsonIndex"></param>
        public void SetUpJsonGrid(int gridJsonIndex)
        {
            try
            {
                var gridType = SaveLoadGridConfig.Instance._loadGridData.Grid[gridJsonIndex];

                ColumnLenght = gridType.ColumnLenght; //column Lenght
                RowLenght = gridType.RowLenght; //RowLenght 
                XSpace = gridType.XSpace; //x_space
                YSpace = gridType.YSpace; //y_space 
                XStart = gridType.XStart; //x_start 
                YStart = gridType.YStart; //y_start 
                ZStart = gridType.ZStart; //z_start    
                Scale = gridType.Scale; //scale
                Rotation = new Vector3(gridType.RotX, gridType.RotY, gridType.RotZ); //cell_rotation  

                EmptyGameObject.transform.position = new Vector3(gridType.EmptyPosX, gridType.EmptyPosy, gridType.EmptyPosZ);
                EmptyGameObject.transform.Rotate(gridType.EmptyRotX, gridType.EmptyRoty, gridType.EmptyRotZ);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int ColumnLenght
        {
            get { return _columnLenght; }
            set { _columnLenght = value; }
        }

        public int RowLenght
        {
            get { return _rowLenght; }
            set { _rowLenght = value; }
        }

        public float XSpace
        {
            get { return _xSpace; }
            set { _xSpace = value; }
        }

        public float YSpace
        {
            get { return _ySpace; }
            set { _ySpace = value; }
        }

        public float Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        public GameObject Prefab
        {
            get { return _prefab; }
            set { _prefab = value; }
        }

        public float XStart
        {
            get { return _xStart; }
            set { _xStart = value; }
        }

        public float YStart
        {
            get { return _yStart; }
            set { _yStart = value; }
        }

        public float ZStart
        {
            get { return _zStart; }
            set { _zStart = value; }
        }

        public List<GameObject> InstanciateGameObjects
        {
            get { return _instanciateGameObjects; }
            set { _instanciateGameObjects = value; }
        }

        public Vector3 Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public GameObject EmptyGameObject
        {
            get { return _emptyGameObject; }
            set { _emptyGameObject = value; }
        }
    }
}

