using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System;

public class ShipNav : MonoBehaviour {
    public UnityEvent RouteFound;
    public UnityEvent RouteNotFound;

    [SerializeField] GameObject StringNames;
    [SerializeField] GameObject StarsObj;
    public GameObject TargetDesination;
    List<GameObject> UnvisitedStar;
    List<GameObject> VisitedStarsInOrder;
    float Nearest = 1000;
    float distance = 0;
    GameObject NearestStar;
    int LaunchLoopInt = 0;
        
    float lerpX;
    float lerpY;
    float lerpZ;
    bool lerping = false;

    // Start is called before the first frame update
    private void Start()
    {     
        UnvisitedStar = new List<GameObject> ();
        StringNames.GetComponent<StarSelector>().CurrentStarString(transform.parent.gameObject.name);
        ListReset();
    }
    public void ListReset() {
        //Resets the lists to be used again by the Search() function
        UnvisitedStar.Clear();
        //puts in each star from stars.starlist into unvisited star. (UnvisitedStar = Stars.Starlist Caused problems)
        foreach (GameObject Star in Stars.StarList){
            UnvisitedStar.Add(Star);
        }
        if(VisitedStarsInOrder != null) TogglePath(VisitedStarsInOrder, false);
        VisitedStarsInOrder = new List<GameObject>();        
        VisitedStarsInOrder.Add(transform.parent.gameObject);       
    }

  

    public void Search() {
        distance = 0;
        Nearest = 1000;
        int i = 0;                
        //While VisitedStarsInOrder isn't empty AND Target destination has not been found AND Index is greater than 0
        while (VisitedStarsInOrder.Count > 0 && VisitedStarsInOrder.Last() != TargetDesination && i >= 0) {
            //Reset the Values for next loop
            NearestStar = null;
            distance = 0;
            Nearest = 1000;
            //Look through each Linked Star in the List of Linked stars on the Current Star(Parent star)
            foreach (GameObject LinkStar in VisitedStarsInOrder[i].GetComponent<Overlap>().links.Keys) {
                //Calucluate which star is closest out of all linkedStars                
                distance = Vector3.Distance(LinkStar.transform.position, TargetDesination.transform.position);
                // Check if the distance is closer than the previous nearest and if the linkstar has not been visited
                if (distance < Nearest && distance > 0 && LinkStar.transform.CompareTag("Star") && UnvisitedStar.Contains(LinkStar) || LinkStar == TargetDesination) {                    
                    NearestStar = LinkStar;
                    Nearest = distance;
                }      
            }
            if(NearestStar == null) {
                // If link stars available remove the last star in list and deincrement
                VisitedStarsInOrder.Remove(VisitedStarsInOrder.Last());            
                i--;
            } else {
                // If a nearest star is found add to VisitedStarsInOrder
                VisitedStarsInOrder.Add(NearestStar);
                //remove it from UnvisitedStar list
                UnvisitedStar.Remove(NearestStar);
                //increment i
                i++;
            }           
        }
        // If the target destination is found in the VisitedStarsInOrder list
        if (VisitedStarsInOrder.Contains(TargetDesination)) {
            // Visited star list count - 1 = how many jumps to the target planet (Starting Planet does not require a jump)                        
            StringNames.GetComponent<StarSelector>().RouteInfoString("Route found! " + (VisitedStarsInOrder.Count - 1).ToString() + " Jumps To Target");
            TogglePath(VisitedStarsInOrder,true);
            RouteFound.Invoke(); //Enable Launch button
        } else {
            // If the target destination is not found or route is impossible
            Debug.Log("route Not found or IMPOSSIBLE!");
            Debug.Log("We searched " + VisitedStarsInOrder.Count + " stars");
            StringNames.GetComponent<StarSelector>().RouteInfoString("RouteImpossible");
            RouteNotFound.Invoke();//Disable Launch button
        }       
    }

    private void TogglePath(List<GameObject> path, bool setActive)
    {
        if(path.Count <= 0) return;
        for (int i = 0; i < path.Count - 1; i++)
        {
            GameObject pathGO;
            path[i].GetComponent<Overlap>().links.TryGetValue(path[i + 1], out pathGO);
            if (setActive)
            {
                pathGO.GetComponent<Renderer>().materials[0].color = Color.green;
            }
            else
            {
                pathGO.GetComponent<Renderer>().materials[0].color = Color.white;
            }
            
        }        
    }
   


    public void launch() {
        if (lerping == false) {
            RouteNotFound.Invoke(); // Dissable the launch button while traveling to stop any errors
            //Loops through all the stars in visisted star in order and lerps to each one untill the
            //target star is reached.
            StringNames.GetComponent<StarSelector>().CurrentStarString(transform.parent.name);
            if (transform.parent == TargetDesination.transform){
                lerping = false;
                LaunchLoopInt = 0;
            }
            else{
                LaunchLoopInt++;
                transform.parent = VisitedStarsInOrder[LaunchLoopInt].transform;
                StartCoroutine(LerpFloat());                
            }
            
        }
    }

    //lerp coroutine
    IEnumerator LerpFloat() {
        lerping = true;
        float time = 0;
        while (time < 1f) {
            float perc = 0;
            perc = time*time;
            time += Time.deltaTime;            
            lerpX = lerp(transform.localPosition.x, 0, perc);
            lerpY = lerp(transform.localPosition.y, 0, perc);
            lerpZ = lerp(transform.localPosition.z, 1, perc);            
            yield return null;
        }        
        lerping = false;
        launch();
    }

    public static float lerp(float startValue, float endValue, float t) {
        return (startValue + (endValue - startValue) * t);
    }
        private void Update() {
        if (lerping == true) {
            transform.localPosition = new Vector3(lerpX, lerpY, lerpZ);
        }                 
    }
}
