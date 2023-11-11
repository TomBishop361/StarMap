using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEditor;
using UnityEngine;

public class Overlap : MonoBehaviour {    
    [SerializeField] GameObject linkGen;
    GameObject Ilink;
    Collider[] tooClose;
    Collider[] InRange;
    public List<GameObject> LinkStars;    
    float Nearest = 1000;
    float distance = 0;
    GameObject NearestStar;
    public static int reps = 0;

    //draws Gizmos the same size/shape as the OverlapSphere
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, Stars.LinkRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Stars.LinkRange * 0.5f);
    }

    // Start is called before the first frame update
    public void Start() {
        LinkStars = new List<GameObject>();        
        //creates a list off all objects in the spheres area.
        InRange = Physics.OverlapSphere(transform.position, Stars.LinkRange);
        tooClose = Physics.OverlapSphere(transform.position, Stars.LinkRange * 0.5f);
        //If a star is in both lists then it is too close and wont be added to the linked list
        foreach(Collider Collider in InRange) {
            if (tooClose.Contains(Collider) && CompareTag("Star")) {
                //Debug.Log(Collider.gameObject.name + " Too Close");
            } else {
                if (Collider.CompareTag("Star") == true){
                    LinkStars.Add(Collider.gameObject);
                }               
            }            
        }

        //if the list is empty look for the nearest star and add it to the linkedStars list.
        if (LinkStars.Count == 0) {            
            for (int i = 0; i < Stars.StarList.Count; i++) { 
                distance = Vector3.Distance(Stars.StarList[i].transform.position, transform.position);                
                if (distance < Nearest && distance > 0 && CompareTag("Star")){                    
                    NearestStar = Stars.StarList[i];                    
                    Nearest = distance;
                }
            }
            LinkStars.Add(NearestStar);
            //add This Star to Other stars linked Star list
            NearestStar.GetComponent<Overlap>().LinkStars.Add(transform.gameObject);
        }
        RouteGen();
    }

    void RouteGen() {
        //for each linked star, make a route
        for (int i = 0; i < LinkStars.Count; i++) {
            reps = i;
            Ilink = Instantiate(linkGen);
            Ilink.transform.parent = gameObject.transform;
            Ilink.transform.localPosition = new Vector3(0, 0, 0);
            Ilink.GetComponent<PlaneVec>().start();
        }       
    }
}
