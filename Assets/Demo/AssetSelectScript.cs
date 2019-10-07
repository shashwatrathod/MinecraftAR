using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AssetSelectScript : MonoBehaviour
{

    public List<Button> buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons[0] = buttons[0].GetComponent<Button>();
        buttons[0].onClick.AddListener(A);

        buttons[1] = buttons[1].GetComponent<Button>();
        buttons[1].onClick.AddListener(B);

        buttons[2] = buttons[2].GetComponent<Button>();
        buttons[2].onClick.AddListener(C);

        buttons[3] = buttons[3].GetComponent<Button>();
        buttons[3].onClick.AddListener(D);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void A()
    {
        ARTapToPlace.material = 0;
    }
    public void B()
    {
        ARTapToPlace.material = 1;
    }
    public void C()
    {
        ARTapToPlace.material = 2;
    }
    public void D()
    {
        ARTapToPlace.material = 3;
    }

}
