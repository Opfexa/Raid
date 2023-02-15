using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaBarScript : MonoBehaviour
{
    [SerializeField] private GameObject manaBox;
    [SerializeField] private GameObject firstManaBox;
    [SerializeField] private List<GameObject> manaBars;
    private PlayerStatus playerStatus;
    private int mana;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GameObject.FindObjectOfType<PlayerStatus>();
        manaBars = new List<GameObject>();
        CreateBar();
    }
    
    // Update is called once per frame
    void Update()
    {
        mana = playerStatus.mana;
        FillMana();
    }
    public void FillMana()
    {
        for (int i = 0; i < mana; i++)
        {
            manaBars[i].GetComponent<Image>().color = Color.magenta;
        }
    }
    public void ResetMana()
    {
        for (int i = 0; i < mana; i++)
        {
            manaBars[i].GetComponent<Image>().color = Color.white;
        }
    }
    //Oyun başladığında mana barı yaratması ve diğerlerine hizalı bir şekilde dizilmesi.
    private void CreateBar()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject bar = Instantiate(manaBox,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z),Quaternion.identity,gameObject.transform);
            bar.GetComponent<RectTransform>().eulerAngles = new Vector3(81.66f,0,0);
            manaBars.Add(bar);
        }
        for (int i = 0; i < manaBars.Count; i++)
        {
            if(i == 0)
            manaBars[0].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(firstManaBox.transform.position.x,(firstManaBox.transform.position.y + 120),(firstManaBox.transform.position.z));
        
            else
            manaBars[i].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(manaBars[i-1].GetComponent<RectTransform>().anchoredPosition3D.x,(manaBars[i-1].GetComponent<RectTransform>().anchoredPosition3D.y + 80),(manaBars[i-1].GetComponent<RectTransform>().anchoredPosition3D.z));
            
        }
    }
}
