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

        public CellArray Board { get; internal set; }

        public void Draw()
        {
            for(int i = 0; i<Board.Dimension ; i++){
                for(int j = 0; j < Board.Dimension ; j++){
                    Console.Write("{0,-5}",Board[i,j].Value);
                }
                Console.WriteLine();
            }
        }
    }
}