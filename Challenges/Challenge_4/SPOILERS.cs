namespace Challenges.Challenge_4;

public class SPOILERS {
    public class Item {
        public int Value    { get; }
        public int HighAlch => (int)(Value * .6);
        public int LowAlch  => (int)(Value * .4);

        public Item(int value) {
            Value = value;
        }
    }

    public class BronzePickaxe : Item {
        public BronzePickaxe() : base(1) { }
    }

    public class RingOfDueling : Item {
        public RingOfDueling() : base(1275) { }
    }

    public class GenieLamp : Item {
        public GenieLamp() : base(200) { }
    }
}