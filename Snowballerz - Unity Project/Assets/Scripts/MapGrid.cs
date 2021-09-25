using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    [System.Serializable]
    public struct Line
    {
        public GridSquare[] P1;
        public GridSquare[] P2;
    }

    [SerializeField]
    private Line[] lines;
    public Line[] Lines => lines;

}
