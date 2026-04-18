using UnityEngine;

public class ShowContainer : MonoBehaviour
{
    bool IsActive = false;
    public GameObject Container;
    public void ActiveContainer()
    {
        if(IsActive == false)
        {
            Container.GetComponent<Animator>().SetBool("Active", true);
            IsActive = true;
        }
        else
        {
            Container.GetComponent<Animator>().SetBool("Active", false);
            IsActive = false;
        }


    }

   
}
