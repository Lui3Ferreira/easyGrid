using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class GridViewModel : MonoBehaviour
{
    public InputField ColField,
        RowField,
        XSpaceField,
        YSpaceField,
        XStartField,
        YStartField,
        ZStartField,
        ScaleField,
        ObjRotXField,
        ObjRotYField,
        ObjRotZField,
        GridRotXField,
        GridRotYField,
        GridRotZField,
        GridPosXField,
        GridPosYField,
        GridPosZField;

    private GridConfig _gridConfig;

    [SerializeField]
    private List<Button> _btns = new List<Button>();   

    //Creates a new model where we save the grids parameters
    public void Init()
    {
        Config = new GridConfig();
    }

    /// <summary>
    /// The folowing fields will update our model with information from the user
    /// </summary>
    public void UpdateColumnLenght()
    {
        if (ColField.text.Contains("-"))
        {
            Debug.Log("Column Length cannot be a negative number");
            ColField.text = Regex.Replace(ColField.text, @"[^0-9]", "");
        }
        else if (ColField.text.Contains("0"))
        {
            Debug.Log("Column Length cannot be a zero!");
            ColField.text = "";
        }
        else
            Config.ColumnLenght = Math.Abs(ConvertTextToNum<int>(ColField));
    }

   
    public void UpdateRowLenght()
    {
        if (RowField.text.Contains("-"))
        {
            Debug.Log("Row Length cannot be a negative number");
            RowField.text = Regex.Replace(RowField.text, @"[^0-9]", "");
        }
        else if (RowField.text.Contains("0"))
        {
            Debug.Log("Column Length cannot be a zero!");
            RowField.text = "";
        }
        else
            Config.RowLenght = Math.Abs(ConvertTextToNum<int>(RowField));
    }

    public void UpdateXSpace()
    {
        Config.XSpace = ConvertTextToNum<float>(XSpaceField);
    }

    public void UpdateYSpace()
    {
        Config.YSpace = ConvertTextToNum<float>(YSpaceField);
    }

    public void UpdateXStart()
    {
        Config.XStart = ConvertTextToNum<float>(XStartField); 
    }

    public void UpdateYStart()
    {
        Config.YStart = ConvertTextToNum<float>(YStartField);
    }

    public void UpdateZStart()
    {
        Config.ZStart = ConvertTextToNum<float>(ZStartField);
    }

    public void UpdateScale()
    {
        if (ScaleField.text.Contains(","))
        {
            Debug.Log("Entrou aqui");
            var newText = ScaleField.text.Replace(',', '.');
            ScaleField.text = newText;
        }  
        else
            Config.Scale = ConvertTextToNum<float>(ScaleField);
    }

    public void UpdateRotX()
    {
        Config.RotX = ConvertTextToNum<float>(ObjRotXField);
    }

    public void UpdateRotY()
    {
        Config.RotY = ConvertTextToNum<float>(ObjRotYField);
    }

    public void UpdateRotZ()
    {
        Config.RotZ = ConvertTextToNum<float>(ObjRotZField); 
    }

    public void UpdateEmptyGoPosX()
    {
        Config.EmptyPosX = ConvertTextToNum<float>(GridPosXField); 
    }

    public void UpdateEmptyGoPosY()
    {
        Config.EmptyPosy = ConvertTextToNum<float>(GridPosYField); 
    }

    public void UpdateEmptyGoPosZ()
    {
        Config.EmptyPosZ = ConvertTextToNum<float>(GridPosZField);
    }

    public void UpdateEmptyGoRotX()
    {
        Config.EmptyRotX = ConvertTextToNum<float>(GridRotXField); 
    }

    public void UpdateEmptyGoRotY()
    {
        Config.EmptyRoty = ConvertTextToNum<float>(GridRotYField); 
    }

    public void UpdateEmptyGoRotZ()
    {
        Config.EmptyRotZ = ConvertTextToNum<float>(GridRotZField);

    }

    //This function will fill the UI inputfields with default parameters of the grid
    public void FillDefaultUiParameters(GridGenerator gridGenerator, GameObject GameContainer)
    {
        ColField.text = gridGenerator.ColumnLenght.ToString();
        RowField.text = gridGenerator.RowLenght.ToString();
        XSpaceField.text = gridGenerator.XSpace.ToString();
        YSpaceField.text = gridGenerator.YSpace.ToString();
        XStartField.text = gridGenerator.XStart.ToString();
        YStartField.text = gridGenerator.YStart.ToString();
        ZStartField.text = gridGenerator.ZStart.ToString();
        ScaleField.text = gridGenerator.Scale.ToString();
        ObjRotXField.text = gridGenerator.Rotation.x.ToString();
        ObjRotYField.text = gridGenerator.Rotation.y.ToString();
        ObjRotZField.text = gridGenerator.Rotation.z.ToString();

        GridPosXField.text = GameContainer.transform.localPosition.x.ToString();
        GridPosYField.text = GameContainer.transform.localPosition.y.ToString();
        GridPosZField.text = GameContainer.transform.localPosition.z.ToString();
        GridRotXField.text = GameContainer.transform.rotation.x.ToString();
        GridRotYField.text = GameContainer.transform.rotation.y.ToString();
        GridRotZField.text = GameContainer.transform.rotation.z.ToString();
    }

    private T ConvertTextToNum<T>(InputField inputfield)
    {
        T convert = default;
 
        try
        {
            inputfield.image.color = Color.white;

            foreach (var btn in _btns)
                btn.interactable = true;
            
            convert = (T)Convert.ChangeType(inputfield.text, typeof(T));
                
            //COMPARE T
            //bool isNegative = Comparer<T>.Default.Compare(convert, default) < 0;
            //Debug.Log("CONVERT " + isNegative);
        }
        catch (Exception e)
        {      
            inputfield.image.color = Color.red;

            foreach (var btn in _btns)
                btn.interactable = false;

            Debug.Log("input value is not valid: " + e.Message);
        }            
        return convert;
    }

    public GridConfig Config
    {
        get { return _gridConfig; }
        set { _gridConfig = value; }
    }

 
}