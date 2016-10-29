using static Kalkulator.Calculator;

namespace Kalkulator
{
    /// <summary>
    /// Representing calculator operation
    /// </summary>
    class Operation
    {
        public double number { get; set; }
        public OPERATION_TYPE type { get; set; }

        public Operation(OPERATION_TYPE type, double number)
        {
            this.number = number;
            this.type = type;
        }
    }
}