using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stars : MonoBehaviour
{    
    //Slider Variables
    [SerializeField] private Slider DensSlider;
    [SerializeField] private Slider RaduisSlider;
    [SerializeField] private GameObject StringManager;

    //Generation variables
    [SerializeField] float InspectLinkRange = 100;
    public static float LinkRange = 100;
    [SerializeField] GameObject Star;
    [SerializeField] GameObject Ship;
    public static List<GameObject> StarList;
    GameObject Istar;

    //Chanagable variables (With sliders)
    public int InspecDens = 2;
    public static int Density = 2;
    public int Radius = 300;

    public void OnSliderChange(){
        InspecDens = ((int)DensSlider.value);
        Radius = ((int)RaduisSlider.value);
        StringManager.GetComponent<StarSelector>().MainMenuStrings(InspecDens,Radius);
    }


    public void Generate(){
        LinkRange = InspectLinkRange;
        Density = InspecDens;
        StarList = new List<GameObject>();
        //instanciates X amount of stars in random locations.
        for (int i = 0; i < Density; i++){
            Istar = Instantiate(Star, new Vector3(UnityEngine.Random.Range(1, Radius), UnityEngine.Random.Range(1, Radius), UnityEngine.Random.Range(1, Radius)), Quaternion.identity);
            //Goes through the enum of Star names and assigns them to each star as they are created.
            foreach (int j in Enum.GetValues(typeof(EnumOfStars.StarNames))){
                Istar.transform.name = Enum.GetName(typeof(EnumOfStars.StarNames), i);
            }
            //add all stars into a list
            StarList.Add(Istar);
        }
        ShipGen();
    }

    void ShipGen(){
        Ship.SetActive(true);
        Ship.transform.parent = StarList[UnityEngine.Random.Range(0, StarList.Count)].transform;
        Ship.transform.localPosition = new Vector3(0, 0, 1);        
    }   
    
}
