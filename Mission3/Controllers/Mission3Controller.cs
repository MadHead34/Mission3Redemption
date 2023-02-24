using Microsoft.AspNetCore.Mvc;

public class RiskCalculationRequest 
{
    public string claimHistory { get; set; }
}

public class RiskRatingResponse
{
    public int Risk_Rating { get; set; }
}

[ApiController]
[Route("api")]
public class Mission3Controller : ControllerBase
{
    [HttpPost]
    public ActionResult<string> CalculateRisk([FromBody] RiskCalculationRequest request)
    {
        if (string.IsNullOrEmpty(request.claimHistory))
        {
            return BadRequest("Claim history cannot be empty");
        }

        var result = CalculateCount(request);
        var response = new RiskRatingResponse(){Risk_Rating = result};
        return Ok(response);

    
    }
    private int CalculateCount(RiskCalculationRequest request)
    {
        string[] riskWords = { "crash", "scratch", "collide", "bump", "smash" };
        string[] words = request.claimHistory.Split(new[] { ' ', '.', ',', ';', ':', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        int riskCount = 0;
        foreach (string word in words)
        {
             foreach (string riskWord in riskWords)
            {
                if (word.StartsWith(riskWord, StringComparison.OrdinalIgnoreCase))
                {
                    riskCount++;

                    if (riskCount == 5)
                    {
                        return riskCount;
                    }
                }
            }
        }
       
        return riskCount;
    }
      
}
