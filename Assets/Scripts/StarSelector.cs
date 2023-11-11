using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class StarSelector : MonoBehaviour
{
    //Main Menu Strings
    [SerializeField] TextMeshProUGUI DenseString;
    [SerializeField] TextMeshProUGUI RadiusString;

    //UI Varaibles
    [SerializeField] GameObject Ship;
    [SerializeField] TextMeshProUGUI SelectedStar;
    [SerializeField] TextMeshProUGUI TargetStar;
    [SerializeField] TextMeshProUGUI CurrentStar;
    [SerializeField] TextMeshProUGUI RouteInfo;



    //Target Star Desplayed on top left of UI
    public void TargetStarString() {
        TargetStar.text = Ship.GetComponent<ShipNav>().TargetDesination.transform.name;
    }

    //Selected star on  the top right
    public void SelectStarString(string name)
    {
        SelectedStar.text = name;

    }
    
    //Current star displayed on the left of the screen
    public void CurrentStarString(string name)
    {
        CurrentStar.text = name;
    }
   // The route information displayed on the left of the UI
    public void RouteInfoString(string info)
    {
        RouteInfo.text = info;
    }

    public void MainMenuStrings(int dense, int radius){
        DenseString.text = dense.ToString();
        RadiusString.text = radius.ToString();
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
