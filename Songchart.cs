using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ChartLoader.NET.Utils;
using ChartLoader.NET.Framework;
using System.Drawing;
using UnityEditor.Experimental.GraphView;

public class Pressure : MonoBehaviour
{
    public static ChartReader chartReader;
    public float speed = 1f;
    public Transform[] notePrefabs;
    void Start()
    {
        chartReader = new ChartReader();
        Chart pressureChart = chartReader.ReadChartFile("C:\\Users\\TrendingPC\\Desktop\\TDR\\FeedBack\\FeedBack0.97b\\Songs\\Pressure\\pressure.chart");

        Note[] expertGuitarNotes = pressureChart.GetNotes("ExpertSingle");
        SpawnNotes(expertGuitarNotes);
    }
    // Aparecen todas las notas
    public void SpawnNotes(Note[] notes)
    {
        foreach(Note note in notes)
        {
            SpawnNote(note);
        }
    }
    // Aparece una nota
    public void SpawnNote(Note note)
    {
        Vector3 point;
        for (int i = 0; i < note.ButtonIndexes.Length; i++)
        {
            if (note.ButtonIndexes[i]) ;
            {
                point = new Vector3(i-2f, 0f, note.Seconds * speed);
                SpawnPrefab(notePrefabs[i], point);
            }
        }
    }
    // Aparece las notas prefabricadas

    public void SpawnPrefab(Transform prefab, Vector3 point)
    {
        Transform tmp = Instantiate(prefab);
        tmp.SetParent(transform);
        tmp.position = point;
    }

}
