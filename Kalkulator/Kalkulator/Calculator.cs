using System;
using System.Collections.Generic;

namespace Kalkulator
{
    class Calculator
    {
        internal enum OPERATION_TYPE { ADDITION, SUBSTRACTION, MULTIPLICATION, DIVISION, PERCENT, EQUALS };
        List<Operation> operationHistory;

        public Calculator()
        {
            operationHistory = new List<Operation>();
        }

        public void AddCalculation(Number x, OPERATION_TYPE currentOperation)
        {
            operationHistory.Add(new Operation(currentOperation, x));
        }

        public string GetHistory()
        {
            string history = string.Empty;
            foreach (var operation in operationHistory)
            {
                string operationSymbol = string.Empty;
                switch (operation.type)
                {
                    case OPERATION_TYPE.ADDITION:
                        {
                            operationSymbol += "+";
                            break;
                        }
                    case OPERATION_TYPE.SUBSTRACTION:
                        {
                            operationSymbol += "-";
                            break;
                        }
                    case OPERATION_TYPE.MULTIPLICATION:
                        {
                            operationSymbol += "x";
                            break;
                        }
                    case OPERATION_TYPE.DIVISION:
                        {
                            operationSymbol += "/";
                            break;
                        }
                    case OPERATION_TYPE.PERCENT:
                        {
                            operationSymbol += "%";
                            break;
                        }
                    case OPERATION_TYPE.EQUALS:
                        {
                            operationSymbol += "=";
                            break;
                        }
                }
                history = String.Format("{0} {1} {2}", history, operation.number.GetNumber, operationSymbol);
            }
            return history;
        }




        public Number GetResult()
        {
            double result = 0;
            if(operationHistory.Count > 0)
            {
                result = operationHistory[0].number.GetNumber;
                for (int i = 1; i < operationHistory.Count; i++)
                {
                    string operationSymbol = string.Empty;
                    
                    switch (operationHistory[i - 1].type)
                    {
                        case OPERATION_TYPE.ADDITION:
                            {
                                result += operationHistory[i].number.GetNumber;
                                break;
                            }
                        case OPERATION_TYPE.SUBSTRACTION:
                            {
                                result -= operationHistory[i].number.GetNumber;
                                break;
                            }
                        case OPERATION_TYPE.MULTIPLICATION:
                            {
                                result *= operationHistory[i].number.GetNumber;
                                break;
                            }
                        case OPERATION_TYPE.DIVISION:
                            {
                                result /= operationHistory[i].number.GetNumber;
                                break;
                            }
                        case OPERATION_TYPE.PERCENT:
                            {
                                result /= operationHistory[i].number.GetNumber;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }

                }
            }
            Number resultNumber = new Number(result);
            if (result < 0) resultNumber.ChangeSign();
            return resultNumber;
        }




        

    }
}