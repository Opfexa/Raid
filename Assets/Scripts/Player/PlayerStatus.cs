using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] internal int mana;
    [SerializeField] private GameObject swordsMan;
    [SerializeField] private GameObject crossbowMan;
    
    private ManaBarScript manaBarScript;
    // Start is called before the first frame update
    void Start()
    {
        mana = 0;
        ManaLoader();
        manaBarScript = GameObject.FindObjectOfType<ManaBarScript>();
        InvokeRepeating("ManaLoader",1,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void ChosenCard(GameObject card,Vector3 cardPosition)
    {
        if(card.name == "SwordsMan")
        {
            if(mana >= 3)
            {
                GameObject temporary = Instantiate(swordsMan,new Vector3(cardPosition.x,1,cardPosition.z),Quaternion.identity);
                temporary.AddComponent<AllyUnit>();
                temporary.AddComponent<AllyAnimations>();
                temporary.AddComponent<AllyAttackScript>();
                temporary.AddComponent<MeleeWarriorScript>();
                mana = mana - 3;
                manaBarScript.ResetMana();
            }
            else
            {
                Debug.Log("Mana yok.");
            }
        }
    }
    private void ManaLoader()
    {
        
        if(mana < 6)
        {
            mana++;
        }
    }
}
