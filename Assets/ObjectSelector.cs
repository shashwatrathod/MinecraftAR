using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectSelector : MonoBehaviour
{
    public int currOpt;
    public List<Button> buttons;

    void Update()
    {
        
        Button justPressed = gameObject.GetComponent<Button>();

       /* if(justPressed == buttons[0])
        {
            ARTapToPlace.material = 0;
            Debug.Log("0");
            SceneManager.LoadScene(1);
        }
        if (justPressed == buttons[1])
        {
            ARTapToPlace.material = 1;
            SceneManager.LoadScene(1);
            Debug.Log("1");
        }
        if (justPressed == buttons[2])
        {
            ARTapToPlace.material = 2;
            SceneManager.LoadScene(1);
            Debug.Log("2");
        }
        if (justPressed == buttons[3])
        {
            ARTapToPlace.material = 3;
            SceneManager.LoadScene(1);
            Debug.Log("3");
       }*/ 
    }

    public void A()
    {
        ARTapToPlace.material = 0;
        SceneManager.LoadScene(1);
        Debug.Log("0");
    }
    public void B()
    {
        ARTapToPlace.material = 1;
        SceneManager.LoadScene(1);
        Debug.Log("1");
    }
    public void C()
    {
        ARTapToPlace.material = 2;
        SceneManager.LoadScene(1);
        Debug.Log("2");
    }
    public void D()
    {
        ARTapToPlace.material = 3;
        SceneManager.LoadScene(1);
        Debug.Log("3");
    }

    /* public int getCurrOption()
     {
         return ARTapToPlace.material;
     }
     */
}
