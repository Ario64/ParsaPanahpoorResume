using System.Collections.Generic;

namespace Resume.Application.Responses;

public class BaseCoomandResponse
{
    public int Id { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
}
