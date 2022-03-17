using System;

namespace Challenges.Challenge_5;

// ReSharper disable once InconsistentNaming
public class SPOILERS {
    public class Item : Challenge_4.SPOILERS.Item, IComparable<Item> {
        public Item(int value) : base(value) { }

        public int CompareTo(Item? other) {
            if (ReferenceEquals(this, other)) {
                return 0;
            }

            if (ReferenceEquals(null, other)) {
                return 1;
            }

            return Value.CompareTo(other.Value);
        }
    }

    public class RingOfDueling : Challenge_4.SPOILERS.RingOfDueling, IComparable<RingOfDueling> {
        public int Charges { get; private set; }

        public bool Teleport() {
            if (Charges > 0) {
                Charges -= 1;
                return true;
            }
            else {
                return false;
            }
        }

        public int CompareTo(RingOfDueling? other) {
            if (ReferenceEquals(this, other)) {
                return 0;
            }

            if (ReferenceEquals(null, other)) {
                return 1;
            }

            return Charges.CompareTo(other.Charges);
        }
    }

    public class GenieLamp { }
}