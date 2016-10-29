using System;
using System.Collections.Generic;

namespace Kalkulator
{
    /// <summary>
    /// Class representing calculator operations
    /// </summary>
    class Calculator
    {
        internal enum OPERATION_TYPE { ADDITION, SUBSTRACTION, MULTIPLICATION, DIVISION, PERCENT, EQUALS };
        List<Operation> operationHistory;

        public Calculator()
        {
            operationHistory = new List<Operation>();
        }

        /// <summary>
        /// Add operation to execution list
        /// </summary>
        /// <param name="x">Number</param>
        /// <param name="currentOperation">Operation type</param>
        public void AddCalculation(double x, OPERATION_TYPE currentOperation)
        {
            operationHistory.Add(new Operation(currentOperation, x));
        }


        /// <summary>
        /// Get operation history
        /// </summary>
        /// <returns>Formated string</returns>
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
                history = String.Format("{0} {1} {2}", history, operation.number, operationSymbol);
            }
            return history;
        }

        /// <summary>
        /// Get a number from execution (throw an exception when wrong index)
        /// </summary>
        /// <param name="x">Index of number in history</param>
        /// <returns>Value of requested number</returns>
        public double GetNumber(int x = -1)
        {
            if (x == -1)
            {
                return operationHistory[operationHistory.Count - 1].number;
            }
            else
            {
                if (!(x >= 0 && x < operationHistory.Count)) throw new InvalidOperationException("Index out of range!");
                return operationHistory[x].number;
            }

        }

        /// <summary>
        /// Check if last operation was requested one
        /// </summary>
        /// <param name="requestedType">Type of operation to check for</param>
        /// <returns>True when types are matched</returns>
        public bool CheckLastOperation(OPERATION_TYPE requestedType)
        {
            if (operationHistory.Count > 0)
                if (operationHistory[operationHistory.Count - 1].type == requestedType)
                    return true;
            return false;
        }

        /// <summary>
        /// Calculate answer
        /// </summary>
        /// <returns>Result of operation in history</returns>
        public double GetResult()
        {
            double result = 0;
            if (operationHistory.Count > 0)
            {
                result = operationHistory[0].number;
                for (int i = 1; i < operationHistory.Count; i++)
                {
                    string operationSymbol = string.Empty;

                    switch (operationHistory[i - 1].type)
                    {
                        case OPERATION_TYPE.ADDITION:
                            {
                                result += operationHistory[i].number;
                                break;
                            }
                        case OPERATION_TYPE.SUBSTRACTION:
                            {
                                result -= operationHistory[i].number;
                                break;
                            }
                        case OPERATION_TYPE.MULTIPLICATION:
                            {
                                result *= operationHistory[i].number;
                                break;
                            }
                        case OPERATION_TYPE.DIVISION:
                            {
                                result /= operationHistory[i].number;
                                break;
                            }
                        case OPERATION_TYPE.PERCENT:
                            {
                                result /= operationHistory[i].number;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }

                }
            }
            return result;
        }






    }
}