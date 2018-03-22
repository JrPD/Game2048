using System;

namespace Game2048 {
    public class Cell : IComparable<Cell>, IEquatable<Cell> {
        public int Value;
        public readonly int X;
        public readonly int Y;

        public Cell () { }

        public Cell (int i, int j) {
            X = i;
            Y = j;
        }

        public int CompareTo (Cell that) {
            if (this.Value > that.Value) return -1;
            if (this.Value == that.Value) return 0;
            return 1;
        }
        public bool HasValue {
            get {
                return Value > 0;
            }
        }

        public void SetEmpty () {
            Value = 0;
        }

        public bool Equals (Cell other) {
            return this.Value == other.Value;
        }
        public override bool Equals (object other) {
            var cell = other as Cell;
            if (cell == null)
                return false;
            return this.Value == cell.Value;
        }
        public static bool operator != (Cell cell1, Cell cell2) {
            return !cell1.Equals (cell2);
        }

        public static bool operator == (Cell cell1, Cell cell2) {
            return cell1.Equals (cell2);
        }
        public override int GetHashCode(){
            return this.GetHashCode();
        }
    }
}