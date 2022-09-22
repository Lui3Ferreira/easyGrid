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

    //Update model for grid column Length 
    public void UpdateColumnLength()
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

    //Update model for grid row length 
    public void UpdateRowLength()
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

    //Update model for XSPACE 
    public void UpdateXSpace()
    {
        Config.XSpace = ConvertTextToNum<float>(XSpaceField);
    }

    //Update model for YSPACE 
    public void UpdateYSpace()
    {
        Config.YSpace = ConvertTextToNum<float>(YSpaceField);
    }

    //Update model for XStart 
    public void UpdateXStart()
    {
        Config.XStart = ConvertTextToNum<float>(XStartField); 
    }

    //Update model for YStart 
    public void UpdateYStart()
    {
        Config.YStart = ConvertTextToNum<float>(YStartField);
    }

    //Update model for ZStart 
    public void UpdateZStart()
    {
        Config.ZStart = ConvertTextToNum<float>(ZStartField);
    }

    //Update model for scale 
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

    //Update model for cell rotation in X
    public void UpdateRotX()
    {
        Config.RotX = ConvertTextToNum<float>(ObjRotXField);
    }

    //Update model for cell rotation in Y
    public void UpdateRotY()
    {
        Config.RotY = ConvertTextToNum<float>(ObjRotYField);
    }

    //Update model for cell rotation in Z 
    public void UpdateRotZ()
    {
        Config.RotZ = ConvertTextToNum<float>(ObjRotZField); 
    }

    //Update model for Empty Game object position in X
    public void UpdateEmptyGoPosX()
    {
        Config.EmptyPosX = ConvertTextToNum<float>(GridPosXField); 
    }

    //Update model for Empty Game object position in Y
    public void UpdateEmptyGoPosY()
    {
        Config.EmptyPosy = ConvertTextToNum<float>(GridPosYField); 
    }

    //Update model for Empty Game object position in Z
    public void UpdateEmptyGoPosZ()
    {
        Config.EmptyPosZ = ConvertTextToNum<float>(GridPosZField);
    }

    //Update model for Empty Game object rotation in X
    public void UpdateEmptyGoRotX()
    {
        Config.EmptyRotX = ConvertTextToNum<float>(GridRotXField); 
    }

    //Update model for Empty Game object rotation in Y
    public void UpdateEmptyGoRotY()
    {
        Config.EmptyRoty = ConvertTextToNum<float>(GridRotYField); 
    }

    //Update model for Empty Game object rotation in Z
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

    /*
     Generic function that will convert inputfield value based on T.
     The function will also evaluate if user input is correct.
    */
    private T ConvertTextToNum<T>(InputField inputfield)
    {
        T convert = default;
   
        try
        {
            inputfield.image.color = Color.white;

            foreach (var btn in _btns)
                btn.interactable = true;
            
            convert = (T)Convert.ChangeType(inputfield.text, typeof(T));

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