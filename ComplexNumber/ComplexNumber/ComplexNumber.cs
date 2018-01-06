using System;

namespace ComplexNumberProject 
{
    /// <summary>
    /// Representation of a complex number with +,-,*,/ operations,
    /// calculating module and comparing two complex numbers
    /// </summary>
    public class ComplexNumber : IEquatable<ComplexNumber>
    {
        /// <summary>
        /// Constructor assigns real and imaginary number parts
        /// </summary>
        /// <param name="realPart"></param>
        /// <param name="imaginaryPart"></param>
        public ComplexNumber(double realPart, double imaginaryPart)
        {
            RealPart = realPart;
            ImaginaryPart = imaginaryPart;
        }

        /// <summary>
        /// Copy constructor assigns real and imaginary parts from another complex number
        /// </summary>
        /// <param name="complexNumber">copied number</param>
        public ComplexNumber(ComplexNumber complexNumber)
        {
            RealPart = complexNumber.RealPart;
            ImaginaryPart = complexNumber.ImaginaryPart;
        }

        private static bool isValueNotValid(double realPart,double imaginaryPart)
        {
            return (double.IsNaN(realPart) || double.IsInfinity(realPart) && (double.IsNaN(imaginaryPart) || double.IsInfinity(imaginaryPart)));
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ComplexNumber()
        {
           
        }

        public double ImaginaryPart
        {
            get;set; 
        }


        public double RealPart
        {
            get;set;
        }

        /// <summary>
        /// Allows to sum two complex numbers
        /// </summary>
        /// <param name="first">left operand</param>
        /// <param name="second">right operand</param>
        /// <returns>resulting number</returns>
        public static ComplexNumber operator+ (ComplexNumber first, ComplexNumber second)
        {
            ComplexNumber resultingNumber = new ComplexNumber();
            resultingNumber.RealPart = first.RealPart + second.RealPart;
            resultingNumber.ImaginaryPart = first.ImaginaryPart + second.ImaginaryPart;
            if (isValueNotValid(resultingNumber.RealPart, resultingNumber.ImaginaryPart))
            {
                throw new ArgumentException();
            }
            return resultingNumber;
        }

        /// <summary>
        /// Allows to get the difference between two numbers
        /// </summary>
        /// <param name="first">left operand</param>
        /// <param name="second">right operand</param>
        /// <returns>resulting number</returns>
        public static ComplexNumber operator -(ComplexNumber first, ComplexNumber second)
        {
            ComplexNumber resultingNumber = new ComplexNumber();
            resultingNumber.RealPart = first.RealPart - second.RealPart;
            resultingNumber.ImaginaryPart = first.ImaginaryPart - second.ImaginaryPart;
            if ( isValueNotValid(resultingNumber.RealPart, resultingNumber.ImaginaryPart))
            {
                throw new ArgumentException();
            }
            return resultingNumber;
        }

        public bool Equals(ComplexNumber secondNumber)
        {
            return (Math.Abs(RealPart - secondNumber.RealPart) < double.Epsilon && Math.Abs(ImaginaryPart - secondNumber.ImaginaryPart) < double.Epsilon );
        }

        /// <summary>
        /// Allows to get the result of dividing of two compex numbers
        /// Throw Argument Exception, if right's operand real and imaginary part == 0
        /// </summary>
        /// <param name="first">left operand</param>
        /// <param name="second">right operand</param>
        /// <returns>resulting number</returns>
        public static ComplexNumber operator /(ComplexNumber first, ComplexNumber second)
        {
            ComplexNumber resultingNumber = new ComplexNumber();
                double denominator = second.RealPart * second.RealPart + second.ImaginaryPart * second.ImaginaryPart;
                resultingNumber.RealPart = (first.RealPart * second.RealPart + first.ImaginaryPart * second.ImaginaryPart)
                    / denominator;
                resultingNumber.ImaginaryPart = (second.RealPart * first.ImaginaryPart - first.RealPart * second.ImaginaryPart) /
                    denominator;

            return resultingNumber;
        }

        /// <summary>
        /// Allows to get the result of multipl of two compex numbers
        /// </summary>
        /// <param name="first">left operand</param>
        /// <param name="second">right operand</param>
        /// <returns>resulting number</returns>
        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second)
        {
            ComplexNumber resultingNumber = new ComplexNumber();
            resultingNumber.RealPart = first.RealPart * second.RealPart - first.ImaginaryPart * second.ImaginaryPart;
            resultingNumber.ImaginaryPart = first.RealPart * second.ImaginaryPart + second.RealPart * first.ImaginaryPart;
            if (isValueNotValid(resultingNumber.RealPart, resultingNumber.ImaginaryPart))
            {
                throw new ArgumentException();
            }
            return resultingNumber;
        }

        /// <summary>
        /// Compare two complex numbers by module
        /// </summary>
        /// <param name="complexNumber">second operand of comparing</param>
        /// <returns> 
        /// -1 if left operand less than right operand
        /// 0 if numbers are equal
        /// 1 if left operand more than right operand
        /// </returns>
        public int CompareByModule(ComplexNumber complexNumber)
        {
            int result = -1;
            double leftNumberModule = GetModule();
            double rightNumberModule = complexNumber.GetModule();
            if ( Math.Abs ( leftNumberModule - rightNumberModule ) < double.Epsilon )
            {
                result = 0;
            }
            else if ( leftNumberModule - rightNumberModule > double.Epsilon)
            {
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// Calculates complex number module
        /// </summary>
        /// <returns>value of module</returns>
        public double GetModule()
        {
            double module;
            checked
            {
                module = Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);
            }
            return module;
        }

        public void ShowNumber()
        {
            Console.WriteLine($"Real part: {0} Imaginary part: {1} ", RealPart, ImaginaryPart);
        }
    }
}
