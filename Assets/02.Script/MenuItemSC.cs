// using System.Collections;
// using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;
//
// public class MenuItemSC : MonoBehaviour
// {
//     [MenuItem("MyMenu/Log Selected Transform Name")]
//     static void LogSelectedTransformName()
//     {
//         Debug.Log("Selected Transform is on " + Selection.activeTransform.gameObject.name + ".");
//         BuildTower(Selection.activeTransform.gameObject);
//     }
// //isValdiateFuction 옵션을 줄 수 있다.
// //아래에서 정의하는 함수의 return값을 bool로 받아서, true일 경우 활성화, false일 경우 비활성화 한다.
//     //[MenuItem("MyMenu/Log Selected Transform Name", isValidateFunction: true)]
//     static bool ValidateLogSelectedTransformName()
//     {
//         return Selection.activeTransform != null;
//     }
//     
//     static void BuildTower(GameObject asd)
//     {
//         float blockHeight = asd.transform.localScale.y;
//         float blockWidth = asd.transform.localScale.x;
//         float blockDepth = asd.transform.localScale.z;
//         
//         GameObject asdd = GameObject.Find("Quad");
//
//         // 층수 만큼 반복
//         for (int i = 0; i < 18; i++)
//         {
//             // 층수에 맞는 대로 배치
//             for (int j = 0; j < 3; j++)
//             {
//                 //홀수층에서는 z축으로 블록을 배치
//                 float xOffset;
//                 float zOffset;
//                 
//                 if (i % 2 == 0)
//                 {
//                     xOffset = j * blockWidth - blockWidth;
//                 }
//                 else
//                 {
//                     xOffset = 0;
//                 }
//                 
//                 if (i % 2 == 0)
//                 {
//                     zOffset = 0.05f;
//                 }
//                 else
//                 {
//                     zOffset = j * (blockDepth - 0.1f);
//                 }
//                 Vector3 position = asdd.transform.position + new Vector3(xOffset, i * blockHeight, zOffset) + new Vector3(0, 0.01245f, 0);
//
//                 Quaternion rotation = Quaternion.Euler(0, (i % 2 == 0) ? 0 : 90, 0);
//                 Instantiate(asd, position, rotation);
//             }
//         }
//     }
// }
