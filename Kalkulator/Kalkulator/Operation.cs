using static Kalkulator.Calculator;

namespace Kalkulator
{
    class Operation
    {
        public Number number { get; set; }
        public OPERATION_TYPE type { get; set; }

        public Operation(OPERATION_TYPE type, Number number)
        {
            this.number = number;
            this.type = type;
        }
    }
}