// using System.Collections;
// using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;
//
// public class JengaSpawner : MonoBehaviour
// {
//     static GameObject jengaPiece;  // Jenga 조각 프리팹
//     static Vector3 spawnPoint = new Vector3(0, 0, 0);  // Jenga 조각의 초기 스폰 지점
//     static float pieceOffsetZ = 0.0125f;  // Jenga 조각의 Z축 오프셋
//     static float pieceOffsetY = 0.009f;  // Jenga 조각의 Y축 오프셋
//     static int layers = 10;  // 생성할 Jenga 층의 총 수
//     static int currentLayer = 0;  // 현재 생성 중인 층을 추적
//     private static float spawnDelay = 1;
//
//     private void Start()
//     {
//         // currentLayer = 0;
//         // SpawnJengaPieces();
//     }
//
//     [MenuItem("MyMenu/MKjenga")]
//     static void SpawnJengaPieces()
//     {
//         jengaPiece = GameObject.Find("JengaPiece");
//         for (int i = 0; i < 8; i++)
//         {
//             if (currentLayer < layers)
//             {
//                 if (currentLayer % 2 == 0)
//                 {
//                     SpawnHorizontalLayer(currentLayer, jengaPiece);
//                 }
//                 else
//                 {
//                     SpawnVerticalLayer(currentLayer, jengaPiece);
//                 }
//                 currentLayer++;
//             
//             }
//         }
//     }
//
//     static void SpawnHorizontalLayer(int layer, GameObject jengaPiece)
//     {
//         Vector3 center = new Vector3(spawnPoint.x, spawnPoint.y + pieceOffsetY * layer, spawnPoint.z);
//         Quaternion rotation = new Quaternion();
//         Instantiate(jengaPiece, center, rotation);
//         Instantiate(jengaPiece, new Vector3(center.x, center.y, center.z + pieceOffsetZ), rotation);
//         Instantiate(jengaPiece, new Vector3(center.x, center.y, center.z - pieceOffsetZ), rotation);
//     }
//
//     static void SpawnVerticalLayer(int layer, GameObject jengaPiece)
//     {
//         Vector3 center = new Vector3(spawnPoint.x, spawnPoint.y + pieceOffsetY * layer, spawnPoint.z);
//         Quaternion rotation = Quaternion.Euler(0, 90, 0);
//         Instantiate(jengaPiece, center, rotation);
//         Instantiate(jengaPiece, new Vector3(center.x + pieceOffsetZ, center.y, center.z), rotation);
//         Instantiate(jengaPiece, new Vector3(center.x - pieceOffsetZ, center.y, center.z), rotation);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaSpawner : MonoBehaviour
{
    public GameObject jengaPiece;  // Jenga 조각 프리팹
    public Vector3 spawnPoint;  // Jenga 조각의 초기 스폰 지점
    private float pieceOffsetZ = 0.25f;  // Jenga 조각의 Z축 오프셋
    private float pieceOffsetY = 0.16f;  // Jenga 조각의 Y축 오프셋
    public int layers = 10;  // 생성할 Jenga 층의 총 수
    private int currentLayer;  // 현재 생성 중인 층을 추적
    private float spawnDelay = 0.1f;  // 각 층을 생성하는 데 걸리는 지연 시간

    private void Start()
    {
        currentLayer = 0;
        SpawnJengaPieces();
    }

    private void SpawnJengaPieces()
    {
        if (currentLayer < layers)
        {
            if (currentLayer % 2 == 0)
            {
                SpawnHorizontalLayer(currentLayer);
            }
            else
            {
                SpawnVerticalLayer(currentLayer);
            }
            currentLayer++;
            Invoke("SpawnJengaPieces", spawnDelay);  // 지연 시간 후 재귀적으로 호출
        }
    }

    private void SpawnHorizontalLayer(int layer)
    {
        Vector3 center = new Vector3(spawnPoint.x, spawnPoint.y + pieceOffsetY * layer, spawnPoint.z);
        Quaternion rotation = new Quaternion();
        Instantiate(jengaPiece, center, rotation);
        Instantiate(jengaPiece, new Vector3(center.x, center.y, center.z + pieceOffsetZ), rotation);
        Instantiate(jengaPiece, new Vector3(center.x, center.y, center.z - pieceOffsetZ), rotation);
    }

    private void SpawnVerticalLayer(int layer)
    {
        Vector3 center = new Vector3(spawnPoint.x, spawnPoint.y + pieceOffsetY * layer, spawnPoint.z);
        Quaternion rotation = Quaternion.Euler(0, 90, 0);
        Instantiate(jengaPiece, center, rotation);
        Instantiate(jengaPiece, new Vector3(center.x + pieceOffsetZ, center.y, center.z), rotation);
        Instantiate(jengaPiece, new Vector3(center.x - pieceOffsetZ, center.y, center.z), rotation);
    }
}
