using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text DinoCollectablesText;
    public Text PlantCollectablesText;

    public Text TotalDinoCollectablesText;
    public Text TotalPlantCollectablesText;

    public int TotalPlantCollectables;
    public int TotalDinoCollectables;

    public int PlantCollectables;
    public int DinoCollectables;

    private void Start()
    {
        TotalDinoCollectablesText.text = TotalPlantCollectables.ToString();
        TotalPlantCollectablesText.text = TotalPlantCollectables.ToString();
    }

    public void IncreasePlantCollectable()
    {
        PlantCollectables += 1;
        PlantCollectablesText.text = PlantCollectables.ToString();
    }

    public void IncreaseDinoCollectable()
    {
        DinoCollectables += 1;
        DinoCollectablesText.text = DinoCollectables.ToString();
    }


}
