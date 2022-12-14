using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions;

public class BusinessProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}