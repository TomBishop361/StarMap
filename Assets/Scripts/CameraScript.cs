using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject SelectedStar;
    [SerializeField] GameObject StringNames;
    [SerializeField] GameObject Ship;

    // Sets the selected star as the target for the ship
    public void SetAsTarget(){
        // Set the selected star as the target destination for the ship's navigation
        Ship.GetComponent<ShipNav>().TargetDesination = SelectedStar;
        //sets Updates the UI String
        StringNames.GetComponent<StarSelector>().TargetStarString();
        //Calls ListReset function
        Ship.GetComponent<ShipNav>().ListReset();
    }


    //moves the camera to the ship and looks at it
    public void ToShip()
    {
        transform.position = new Vector3(Ship.transform.position.x, Ship.transform.position.y + 10, Ship.transform.position.z);
        transform.LookAt(Ship.transform);
    }


    void OnSelect()
    {        
        //Raycast from centre of camera screen
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);   
            //Checks to see if it hit a star
            if (hit.transform.CompareTag("Star"))
            {
                //Updates the UI
                SelectedStar = hit.transform.gameObject;
                StringNames.GetComponent<StarSelector>().SelectStarString(SelectedStar.transform.name);              
                
            }
        }
    }
}