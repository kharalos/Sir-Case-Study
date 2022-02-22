using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] private GameObject character, crystal;
   List<GameObject> crystals = new List<GameObject>();
   private int currentCrystals = 0;
   [SerializeField] private float spawnRangeX = 4.5f, spawnRangeY = 9f;
   [SerializeField] private int maxCrystalSize = 5;
   private int score = 0;

   public void Reset(){
       character.GetComponent<Rigidbody>().MovePosition(new Vector3(0.0f, 1f, -5.5f));
       foreach(GameObject crystallite in crystals){
           if (crystallite != null) {
               crystallite.GetComponent<CrystalHandler>().Kill();
           }
       }
       crystals.Clear();
       currentCrystals = 0;
       score = 0;
       for(int i = 0; i < maxCrystalSize; i++){
           CreateCrystal();
       }

   }
   public void CrystalGained(){
       score += 10;
       FindObjectOfType<UIManager>().UpdateScore(score.ToString());
       currentCrystals--;
       if(score > 99){
           FindObjectOfType<UIManager>().CallFinishScreen();
       }
       else
        Invoke("CreateCrystal", Random.Range(0.3f, 2f));
   }
   public void CreateCrystal(){
        GameObject newCrystal = Instantiate(crystal, new Vector3(Random.Range(-spawnRangeX,spawnRangeX), 0.0f,Random.Range(-spawnRangeY,spawnRangeY)),Quaternion.identity);
        crystals.Add(newCrystal);
        currentCrystals++;
   }

}
