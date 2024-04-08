namespace CalculatorEngine;

using System;

public class Result<T>
{
        public T Value { get; init; }
        public bool IsSuccess { get; init; }
        public string Operation { get; init; }
        public string? ErrorMessage { get; init; }

        public Result(T value, bool isSuccess, string operation, string? errorMessage = null)
        {
                Value = value;
                IsSuccess = isSuccess;
                Operation = operation;
                ErrorMessage = errorMessage;
        }

        public Result(bool isSuccess, string operation, string? errorMessage = null)
        {
                IsSuccess = isSuccess;
                Operation = operation;
                ErrorMessage = errorMessage;
        }

        public override string ToString() => IsSuccess
                ? $"{Operation} = {Value}"
                : $"{Operation} => {ErrorMessage}";

        public static implicit operator Result<T>(T value) => new(value, true, string.Empty);

        public static implicit operator Result<T>(string errorMessage) => new(default!, false, string.Empty, errorMessage);
}