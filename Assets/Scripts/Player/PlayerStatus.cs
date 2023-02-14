using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int mana;
    [SerializeField] private GameObject swordsMan;
    [SerializeField] private GameObject crossbowMan;
    // Start is called before the first frame update
    void Start()
    {
        mana = 0;
        ManaLoader();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void ChosenCard(GameObject card,Vector3 cardPosition)
    {
        if(card.name == "SwordsMan")
        {
            GameObject temporary = Instantiate(swordsMan,new Vector3(cardPosition.x,1,cardPosition.z),Quaternion.identity);
        }
    }
    private void ManaLoader()
    {
        if(mana < 5)
        {
            StartCoroutine(ManaLoaderCountDown());
        }
    }
    IEnumerator ManaLoaderCountDown()
    {
        yield return new WaitForSeconds(1);
        mana++;
        ManaLoader();
    }
}
