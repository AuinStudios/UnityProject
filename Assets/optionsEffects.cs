
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class optionsEffects : MonoBehaviour
{
    public Image selectedcolor;
    public void Selected()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        if (EventSystem.current.alreadySelecting != gameObject )
        {
         EventSystem.current.SetSelectedGameObject(gameObject);
        }
    
            
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            gameObject.GetComponent<Animator>().SetBool("isonmouse", true);
        }
     

    }
    public void Update()
    {
        if(selectedcolor.color ==  new Color (19, 168 , 255, 255))
        {
            selectedcolor.color = new Color(0, 222, 255, 255);
        }
    }

    public void unSelected()
    {

        gameObject.transform.localScale = new Vector3(1.441417f, 0.5779613f, 1f);
        if (EventSystem.current.currentSelectedGameObject != null )
        {
            gameObject.GetComponent<Animator>().SetBool("isonmouse", false);
        }
     
    }

    public void clicked()
    {


        gameObject.GetComponent<Animator>().enabled = false;

        if (EventSystem.current.currentSelectedGameObject == this)
        {
           
        EventSystem.current.SetSelectedGameObject(null);

            gameObject.transform.localScale = new Vector3(1.499074f, 0.6010798f, 1.04f);
        }
   
         

    } 
  
}
