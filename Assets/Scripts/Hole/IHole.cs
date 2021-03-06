using System.Collections.Generic;
using UnityEngine;

namespace Hole
{
    //Bu script deliğe ulaşmamızı sağlar.
    //Helper iletişim kanalıyken IHole gerekli verileri oluşturmamızı sağlar.
    public static class HoleHelper
    {
        public static List<IHole> HoleList = new List<IHole>();
        public static void InitializeHole(this IHole hole)
        {
            HoleList.Add(hole);
        }

        public static void DestroyHole(this IHole hole)
        {
            HoleList.Remove(hole);
        }
    }
    
    public interface IHole
    {
        Transform HoleTransform { get; }
        void IncreaseTurn();
    }
}