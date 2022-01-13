using System;
using UnityEngine;

namespace Project.Scripts.MVC
{
    
    public enum ChunkType : Int32
    {
        One = 0,
        Two = 1
    }

    public class Chunk : MonoBehaviour
    {
        public Transform End;
        public Transform Start;

        public ChunkType Type;

        public Chunk(ChunkType type)
        {
            Type = type;
        }

        
    }

    /*public class Operations
    {
        public ChunkType Type { get; set; }
        
        public Operations() {}

        public Operations(int type)
        {
            
        }
        
        public static explicit operator Operations (int type)
        {
            return new Operations()
            {
                Type = (ChunkType)type
            };
        }
    }*/
}

