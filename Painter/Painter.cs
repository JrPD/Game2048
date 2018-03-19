using System;

namespace Game2048.Paint
{
    interface IPainter
    {
        void Draw();
    }
    public class Painter : IPainter
    {

        public Painter()
        {
        }

        public int[,] Board { get; internal set; }

        public void Draw()
        {
            for(int i = 0; i<Board.GetLength(0) ; i++){
                for(int j = 0; j < Board.GetLength(1) ; j++){
                    Console.Write("{0,-5}",Board[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}