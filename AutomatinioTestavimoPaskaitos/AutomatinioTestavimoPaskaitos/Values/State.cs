using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Values
{
    public class State
    {
        public static State CALIFORNIA = new State("California", 0);
        public static State FLORIDA = new State("Florida", 1);
        public static State NEW_JERSEY = new State("New Jersey", 2);
        public static State NEW_YORK = new State("New York", 3);
        public static State OHIO = new State("Ohio", 4);
        public static State TEXAS = new State("Texas", 5);
        public static State PENNSYLVANIA = new State("Pennsylvania", 6);
        public static State WASHINGTON = new State("Washington", 7);

        public string state;
        public int index;

        public State(string state, int index)
        {
            this.state = state;
            this.index = index;
        }
    }
}
