namespace CalculatorEngine;

public class Result
{
        public double Val { get; set;} = 0.0;
        public bool Success { get; set; }
        public string Op { get; set; } // for example, "1.25 + 3.8 ="
        public string Err { get; set; } // for example, "" or "Not A Number

        public Result(double val, bool success, string op, string err)
        {
                Val = val;
                Success = success;
                Op = op;
                Err = err;
        }
        public Result(bool success, string op, string err)
        {
                Success = success;
                Op = op;
                Err = err;
        }

        public override string ToString()
        {
                return $"{Val}, {Success}, {Op}, {Err}";
        }
}